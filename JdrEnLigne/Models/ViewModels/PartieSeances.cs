using Domain.Entities;

namespace JdrEnLigne.Models.ViewModels
{
	public class PartieSeances
	{
		public string MeneurId { get; set; }
		public long PartieId {  get; set; }
		public List<Seance> SeancesList { get; set; } = new List<Seance>();
	}
}
