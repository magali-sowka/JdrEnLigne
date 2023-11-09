using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using JdrEnLigne.Models.ViewModels;
using JdrEnLigne.Models;
using JdrEnLigne.Models.PageModels;

namespace JdrEnLigne.Areas.Joueur.Pages.Parties
{
	[Area("Joueur")]
	[Authorize(Roles = "Joueur")]
	public class IndexModel : IndexPartiePM
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<JdrUser> _userManager;

		public IndexModel(IUnitOfWork unitOfWork, UserManager<JdrUser> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public List<PartieVM> Parties { get; set; }
		public Pagination Pages { get; set; }
		public int PageSize { get; set; }
		public Filter Filter { get; set; }
		public string DateSort { get; set; }
		public string[] Filters { get; set; }
		public string? SearchText { get; set; }

		public async Task OnGetMeneurIndexAsync(int pg = 1, int pageSize = 10, string dateSort = "date_desc", string searchText = "", params string[] filter)
		{
			ClaimsPrincipal currentUser = User;
			string meneurId = _userManager.GetUserId(currentUser);
			JdrUser meneur = await _unitOfWork.Joueurs.GetAsync(m => m.Id == meneurId, includeProperties: "PartiesMeneur,PartiesMeneur.Genres");
			IQueryable<Partie> allParties = meneur.PartiesMeneur.AsQueryable();
			await IndexAsync(allParties, pg, pageSize, dateSort, searchText, filter);
			ViewData["Title"] = "Meneur";
		}

		public async Task OnGetJoueurIndexAsync(int pg = 1, int pageSize = 10, string dateSort = "date_desc", string searchText = "", params string[] filter)
		{
			ClaimsPrincipal currentUser = User;
			string joueurId = _userManager.GetUserId(currentUser);
			JdrUser joueur = await _unitOfWork.Joueurs.GetAsync(m => m.Id == joueurId, includeProperties: "PartiesJoueur,PartiesJoueur.Genres");
			IQueryable<Partie> allParties = joueur.PartiesJoueur.AsQueryable();
			await IndexAsync(allParties, pg, pageSize, dateSort, searchText, filter);
			ViewData["Title"] = "Joueur";
		}

		public async Task IndexAsync(IQueryable<Partie> allParties, int pg, int pageSize, string dateSort, string searchText, params string[]? filter)
		{
			if (pg < 1)
				pg = 1;

			List<Discriminator> selectedFormats = new List<Discriminator>();
			List<short> selectedGenres = new List<short>();
			List<Statut> selectedStatuts = new List<Statut>();

			for (int i = 0; i < filter.Length; i++)
			{
				string[] par = filter[i].Split('_');
				switch (par[0])
				{
					case "format":
						selectedFormats.Add((Discriminator)Enum.Parse(typeof(Discriminator), par[1]));
						break;
					case "statut":
						selectedStatuts.Add((Statut)Enum.Parse(typeof(Statut), par[1]));
						break;
					case "genre":
						selectedGenres.Add(short.Parse(par[1]));
						break;
				}
			}

			IQueryable<Partie> filteredParties = await GetFilteredParties(allParties, selectedGenres, selectedFormats, selectedStatuts, dateSort,searchText);
			Pagination pages = new Pagination("Joueur", "/Parties/Index", "MeneurIndex", filteredParties.Count(), pg, pageSize, dateSort, filter);
			Filter = new Filter("Joueur", "/Parties/Index", "MeneurIndex", filteredParties, selectedGenres, selectedFormats, selectedStatuts);

			int partiesSkip = (pg - 1) * pageSize;
			List<Partie> parties = filteredParties.Skip(partiesSkip).Take(pages.PageSize).ToList();

			List<PartieVM> partiesVM = new List<PartieVM>();

			foreach (Partie partie in parties)
			{
				PartieVM p = partie.GetType() == typeof(Oneshot) ?
						new PartieVM((Oneshot)partie) :
						new PartieVM((Campagne)partie);
				partiesVM.Add(p);
			}

			Parties = partiesVM;
			Pages = pages;
			PageSize = pageSize;
			Filters = filter.ToArray();
			DateSort = dateSort;
			SearchText = searchText;

			GetPageSizes(PageSize, DateSort, Filters);
		}
		public async Task<IQueryable<Partie>> GetFilteredParties(IQueryable<Partie> parties, List<short> selectedGenres, List<Discriminator> selectedFormats, List<Statut> selectedStatuts, string sort, string searchText)
		{
			List<Func<Partie, bool>> genrePredicates = new List<Func<Partie, bool>>();
			List<Func<Partie, bool>> statutPredicates = new List<Func<Partie, bool>>();
			List<Func<Partie, bool>> formatPredicates = new List<Func<Partie, bool>>();

			if (selectedGenres.Count > 0)
			{
				foreach (short id in selectedGenres)
				{
					Genre g = await _unitOfWork.Genres.GetByIdAsync(id);
					if (g != null)
					{
						genrePredicates.Add(p => p.Genres.Contains(g));
					}
				}
			}

			if (selectedFormats.Count != 0)
			{
				foreach (Discriminator format in selectedFormats)
				{
					if (format == Discriminator.Oneshot)
					{
						formatPredicates.Add(p => p.GetType() == typeof(Oneshot));
					}
					if (format == Discriminator.Campagne)
					{
						formatPredicates.Add(p => p.GetType() == typeof(Campagne));
					}
				}
			}

			if (selectedStatuts.Count != 0)
			{
				foreach (Statut statut in selectedStatuts)
				{
					statutPredicates.Add(p => p.Statut == statut);
				}
			}

			var filteredParties = parties
				.Where(p=>p.Titre.Contains(searchText))
				.Where(And<Partie>(new List<Func<Partie, bool>> {
					Or<Partie>(statutPredicates),
					Or<Partie>(formatPredicates),
					Or<Partie>(genrePredicates)}))
				.AsQueryable();

			if (sort == "date_desc")
				filteredParties = filteredParties.OrderByDescending(p => p.DateCreaPartie);
			else
				filteredParties = filteredParties.OrderBy(p => p.DateCreaPartie);

			return filteredParties;

		}

		public static bool In(ICollection<Genre> genres, IEnumerable<Genre> selectedGenres)
		{
			if (selectedGenres.Count() != 0)
			{
				foreach (var genre in selectedGenres)
				{
					if (genres.Contains(genre)) return true;
				}
				return false;
			}
			return true;
		}

		public static Func<T, bool> Or<T>(List<Func<T, bool>> predicates)
		{
			return delegate (T item)
			{
				if (predicates.Count() != 0)
				{
					foreach (Func<T, bool> p in predicates)
					{
						if (p(item))
						{
							return true;
						}
					}
					return false;
				}
				return true;
			};
		}

		public static Func<T, bool> And<T>(List<Func<T, bool>> predicates)
		{
			return delegate (T item)
			{
				if (predicates.Count() != 0)
				{
					foreach (Func<T, bool> p in predicates)
					{
						if (!p(item))
						{
							return false;
						}
					}
					return true;
				}
				return true;
			};
		}
	}
}