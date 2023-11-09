using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces;
using JdrEnLigne.Models.ViewModels;

namespace JdrEnLigne.Areas.Joueur.Pages.Parties
{
	[Area("Joueur")]
	[Authorize(Roles = "Joueur")]
	public class DetailsModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public DetailsModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public PartieVM Partie { get; set; }
		public PartieJoueurs Joueurs { get; set; }
		public PartieSeances Seances { get; set; }

		public async Task<IActionResult> OnGetAsync(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Partie partie = await _unitOfWork.Parties.GetAsync(m => m.PartieId == id, "Meneur,Joueurs,Genres,Seances");

			if (partie == null)
			{
				return NotFound();
			}

			Joueurs = GetJoueurs(partie);

			Seances = new PartieSeances();
			Seances.PartieId = partie.PartieId;
			Seances.MeneurId = partie.MeneurId;
			Seances.SeancesList = partie.Seances.ToList();

			Partie = partie.GetType() == typeof(Oneshot) ?
				new PartieVM((Oneshot)partie) :
				new PartieVM((Campagne)partie);

			return Page();
		}

		public async Task<PartialViewResult> OnGetJoueursPartialAsync(long? id)
		{
			if (id == null)
			{
				return Partial("_NotFoundPartial");
			}

			Partie? partie = await _unitOfWork.Parties.GetAsync(m => m.PartieId == id, "Joueurs");

			if (partie == null)
			{
				return Partial("_NotFoundPartial");
			}

			Joueurs = GetJoueurs(partie);

			return Partial("_JoueursDetailsPartial", Joueurs);
		}

		private static PartieJoueurs GetJoueurs(Partie partie)
		{
			PartieJoueurs joueurs = new PartieJoueurs();
			joueurs.PartieId = partie.PartieId;
			joueurs.MeneurId = partie.MeneurId;
			foreach (JdrUser joueur in partie.Joueurs)
			{
				joueurs.JoueursList.Add(new JoueurVM(joueur));
			}

			return joueurs;

		}
	}
}

