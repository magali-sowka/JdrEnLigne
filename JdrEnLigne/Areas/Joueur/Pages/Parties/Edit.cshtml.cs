using Domain.Entities;
using Domain.Interfaces;
using JdrEnLigne.Models.PageModels;
using JdrEnLigne.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JdrEnLigne.Areas.Joueur.Pages.Parties
{
	public class EditModel : CreateOrEditPartiePM
	{
		private readonly IUnitOfWork _unitOfWork;

		public EditModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public PartieVM Partie { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Partie partieToUpdate = await _unitOfWork.Parties.GetAsync(m => m.PartieId == id, "Meneur,Genres");

			if (partieToUpdate == null)
			{
				return NotFound();
			}

			if(partieToUpdate.GetType() == typeof(Oneshot))
			{
				Partie = new PartieVM((Oneshot)partieToUpdate);
				GetStatutNames(partieToUpdate);
				GetSelectedGenres(_unitOfWork, partieToUpdate);
				return Page();
			}

			else
			{
				Partie = new PartieVM((Campagne)partieToUpdate);
				GetStatutNames(partieToUpdate);
				GetSelectedGenres(_unitOfWork, partieToUpdate);
				return Page();
			}
		}

		public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenres)
		{
			if (selectedGenres == null || selectedGenres.Length == 0)
			{
				ModelState.AddModelError("Partie.Genres", "Veuillez sélectionner au moins un thème.");

			}

			if (Partie.Format == Discriminator.Oneshot)
			{
				if (Partie.NbSeances <= 0)
				{
					ModelState.AddModelError("Partie.NbSeances", "Veuillez indiquer le nombre estimé de séances.");
				}
			}

			if (Partie.Format == Discriminator.Campagne)
			{
				if (Partie.Duree == null)
				{
					ModelState.AddModelError("Partie.Duree", "Veuiller donner une durée approximative de la campagne.");
				}
				if (Partie.Frequence == null)
				{
					ModelState.AddModelError("Partie.Frequence", "Veuiller donner la fréquence des séances.");
				}
			}

			if (id == null)
			{
				return NotFound();
			}

			Partie partieToUpdate = await _unitOfWork.Parties.GetAsync(p => p.PartieId == id, "Genres");

			if (partieToUpdate == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				if (partieToUpdate.GetType() == typeof(Oneshot))
				{
					Oneshot oneshot = (Oneshot)partieToUpdate;
					unsafe
					{
						Oneshot* o = &oneshot;
						Partie.UpdateOneshot(o);
					}

					await UpdatePartieGenresAsync(selectedGenres, oneshot);
					await _unitOfWork.CompleteAsync();
					return RedirectToPage("/Parties/Details", new { area = "Joueur", id = id});

				}

				if (partieToUpdate.GetType() == typeof(Campagne))
				{
					Campagne campagne = (Campagne)partieToUpdate;
					unsafe
					{

						Campagne* c = &campagne;
						Partie.UpdateCampagne(c);
					}
					await UpdatePartieGenresAsync(selectedGenres, campagne);
					await _unitOfWork.CompleteAsync();
					return RedirectToPage("/Parties/Details", new { area = "Joueur", id = id});

				}

				GetSelectedGenres(_unitOfWork, partieToUpdate);
				return Page();
			}

			GetSelectedGenres(_unitOfWork, partieToUpdate);
			return Page();
		}

		private async Task UpdatePartieGenresAsync(string[] selectedGenres, Partie partie)
		{
			if (selectedGenres == null)
			{
				partie.Genres = new List<Genre>();
				return;
			}

			var selectedGenresHS = new HashSet<string>(selectedGenres);
			var partieGenres = new HashSet<short>(partie.Genres.Select(g => g.GenreId));
			foreach (var genre in await _unitOfWork.Genres.GetAllAsync())
			{
				if (selectedGenresHS.Contains(genre.GenreId.ToString()))
				{
					if (!partieGenres.Contains(genre.GenreId))
					{
						partie.Genres.Add(genre);
					}
				}
				else
				{
					if (partieGenres.Contains(genre.GenreId))
					{
						var genreToRemove = partie.Genres.Single(g => g.GenreId == genre.GenreId);
						partie.Genres.Remove(genreToRemove);
					}
				}
			}
		}
	}
}
