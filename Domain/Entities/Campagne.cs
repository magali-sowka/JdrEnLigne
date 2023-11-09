namespace Domain.Entities;

public partial class Campagne : Partie
{
	private string duree;
	private string frequence;
	public string Duree
	{
		get { return duree; }
		set { duree = value; }
	}

	public string Frequence
	{
		get { return frequence; }
		set { frequence = value; }
	}
	public Campagne() { }

	public Campagne(long partieId, string titre, string systeme, string vtt, byte nbPlacesTot, JdrUser meneur, string duree, string frequence) : base(partieId, titre, systeme, vtt, nbPlacesTot, meneur)
	{
		Duree = duree;
		Frequence = frequence;
	}
}
