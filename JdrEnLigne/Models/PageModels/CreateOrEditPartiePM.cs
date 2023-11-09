using Domain.Entities;
using Domain.Interfaces;
using JdrEnLigne.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JdrEnLigne.Models.PageModels
{
    [Area("Joueur")]
	[Authorize(Roles = "Joueur")]
	public class CreateOrEditPartiePM : PageModel
	{
		public List<SelectListItem> StatutNamesList { get; set; }
		public List<SelectedGenre> SelectedGenresList { get; set; }

		public void GetStatutNames(Partie partie)
		{
			StatutNamesList = new List<SelectListItem>();
			foreach (Statut statut in Enum.GetValues(typeof(Statut)))
			{
				StatutNamesList.Add(new SelectListItem
				{
					Text = statut.GetEnumDescription(),
					Value = statut.ToString(),
					Selected = (partie.Statut == statut) ? true : false
				});
			}
		}
		public void GetSelectedGenres(IUnitOfWork unitOfWork, Partie partie)
		{
			var allGenres = unitOfWork.Genres.GetAllIQ();
			var partieSelectedGenres = new HashSet<short>(partie.Genres.Select(g => g.GenreId));
			SelectedGenresList = new List<SelectedGenre>();
			foreach (var genre in allGenres)
			{
				SelectedGenresList.Add(new SelectedGenre(
					genre.GenreId, 
					genre.Libelle,
					partieSelectedGenres.Contains(genre.GenreId)));
			}
		}
	}
}
