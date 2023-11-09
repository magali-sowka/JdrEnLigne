using Domain.Entities;

namespace JdrEnLigne.Models.ViewModels
{
	public class JoueurVM
	{
		private string joueurId;
		private string pseudo;

		public string JoueurId { get {  return joueurId; } set {  joueurId = value; } }
		public string Pseudo { get { return pseudo; } set { pseudo = value; } }

		public JoueurVM(JdrUser joueur) { 
			joueurId = joueur.Id;
			pseudo = joueur.Pseudo;
		}
	}
}
