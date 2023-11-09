using Domain.Entities;

namespace JdrEnLigne.Models.ViewModels
{
	public class SelectedStatut
	{
		public Statut Statut { get; set; }
		public bool Selected { get; set; }

		public SelectedStatut(Statut statut, bool selected)
		{
			Statut = statut;
			Selected = selected;
		}
	}
}
