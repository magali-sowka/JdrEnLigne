using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JdrEnLigne.Areas.Joueur.Pages.Joueurs
{
	public class RemoveModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public RemoveModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet()
		{
		}

		public async Task<JsonResult> OnPostAsync(long? partieId, string joueurId)
		{
			if (partieId == null)
			{
				return new JsonResult(new { success = false, message = "Erreur pendant la suppression" });
			}

			Partie? partie = await _unitOfWork.Parties.GetAsync(p => p.PartieId == partieId, "Joueurs");
			JdrUser? joueur = await _unitOfWork.Joueurs.GetByIdAsync(joueurId);

			if (partie == null || joueur == null)
			{
				return new JsonResult(new { success = false, message = "Erreur pendant la suppression" });
			}

			partie.Joueurs.Remove(joueur);
			await _unitOfWork.CompleteAsync();
			return new JsonResult(new
			{
				success = true,
				message = "Le joueur a bien été retiré de la liste",
				html = Url.Page("/Parties/Details", "JoueursPartial", new { area = "Joueur", id = partieId })
			});
		}
	}
}
