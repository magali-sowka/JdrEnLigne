namespace JdrEnLigne.Models.ViewModels
{
	public class PartieJoueurs
	{
		public long PartieId { get; set; }
		public string MeneurId { get; set; }
		public List<JoueurVM> JoueursList { get; set; } = new List<JoueurVM>();
	}
}
