namespace Domain.Entities;

public partial class Oneshot : Partie
{
	private byte nbSeances;
	public byte NbSeances
	{
		get { return nbSeances; }
		set { nbSeances = value; }
	}
	public Oneshot() { }

	public Oneshot(long partieId, string titre, string systeme, string vtt, byte nbPlacesTot, JdrUser meneur, byte nbSeances) : base(partieId, titre, systeme, vtt, nbPlacesTot, meneur)
	{
		NbSeances = nbSeances;
	}
}
