using Domain.Entities;
using Domain.Interfaces;
using JdrEnLigne.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JdrEnLigne.Areas.Joueur.Pages.Joueurs
{
	[Area("Joueur")]
	[Authorize(Roles = "Joueur")]
	public class AddModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public AddModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Partie Partie { get; set; }
		public List<JoueurVM> Joueurs { get; set; }
		public string SearchJoueur { get; set; }

		public async Task<IActionResult> OnGetAsync(long id, string? searchText = null)
		{
			Partie = await _unitOfWork.Parties.GetAsync(p => p.PartieId == id, includeProperties: "Joueurs");
			SearchJoueur = searchText;
			Joueurs = new List<JoueurVM>();

			List<JdrUser> foundJoueurs = new List<JdrUser>();

			if (!string.IsNullOrEmpty(searchText))
			{
				foundJoueurs = _unitOfWork.Joueurs
					.GetAllIQ()
					.Where(j => j.Pseudo.Contains(searchText))
					.ToList();
			}

			foreach (JdrUser joueur in foundJoueurs)
			{
				Joueurs.Add(new JoueurVM(joueur));
			}

			if (Partie == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(long partieId, string joueurId)
		{
			JdrUser? joueur = await _unitOfWork.Joueurs.GetByIdAsync(joueurId);
			Partie? partie = await _unitOfWork.Parties.GetAsync(p => p.PartieId == partieId, includeProperties: "Joueurs");
			if (joueur == null || partie == null)
			{
				return NotFound();
			}

			if (!partie.Joueurs.Contains(joueur))
			{
				partie.Joueurs.Add(joueur);
				await _unitOfWork.CompleteAsync();
			}
			return RedirectToPage(pageName:"/Parties/Details", pageHandler:"", routeValues:new { area = "Joueur", id = partie.PartieId},fragment: "joueursDetails");
		}

	}
}
