using System.ComponentModel;

namespace Domain.Entities;

public enum Statut
{
	[Description("Recrutement en cours")]
	RecrutementEnCours, 
	[Description("Recrutement terminé")]
	RecrutementTermine, 
	[Description("Partie terminée")]
	PartieTerminee, 
	[Description("Partie annulée")]
	PartieAnnulee, 
	[Description("Partie archivée")]
	PartieArchivee
}
public abstract class Partie
{
	private long partieId;
	private string titre;
	private string systeme;
	private string vtt;
	private string? applis;
	private string? description;
	private byte nbPlacesTot;
	private Statut statut = Statut.RecrutementEnCours;
	private DateTime dateCreaPartie;
	private string meneurId;
	private JdrUser meneur;
	private ICollection<Seance> seances = new List<Seance>();
	private ICollection<Genre> genres = new List<Genre>();
	private ICollection<JdrUser> joueurs = new List<JdrUser>();

	public long PartieId
	{
		get { return partieId; }
		private set { partieId = value; }
	}

	public string Titre
	{
		get { return titre; }
		set { titre = value; }
	}

	public string Systeme
	{
		get { return systeme; }
		set { systeme = value; }
	}

	public string Vtt
	{
		get { return vtt; }
		set { vtt = value; }
	}

	public string? Applis
	{
		get { return applis; }
		set { applis = value; }
	}

	public string? Description
	{
		get { return description; }
		set { description = value; }
	}

	public byte NbPlacesTot
	{
		get { return nbPlacesTot; }
		set { nbPlacesTot = value; }
	}

	public Statut Statut
	{
		get { return statut; }
		set { statut = value; }
	}

	public DateTime DateCreaPartie
	{
		get { return dateCreaPartie; }
		set { dateCreaPartie = value; }
	}

	public string MeneurId
	{
		get { return meneurId; }
		set { meneurId = value; }
	}

	public JdrUser Meneur
	{
		get { return meneur; }
		set { meneur = value; }
	}

	public ICollection<Seance> Seances
	{
		get { return seances; }
		set { seances = value; }
	}

	public ICollection<Genre> Genres
	{
		get { return genres; }
		set { genres = value; }
	}

	public ICollection<JdrUser> Joueurs
	{
		get { return joueurs; }
		set { joueurs = value; }
	}

	public Partie()
	{
	}
	public Partie(long partieId, string titre, string systeme, string vtt, byte nbPlacesTot, JdrUser meneur)
	{
		PartieId = partieId;
		Titre = titre;
		Systeme = systeme;
		Vtt = vtt;
		NbPlacesTot = nbPlacesTot;
		Meneur = meneur;
		MeneurId = meneur.Id;
		DateCreaPartie = DateTime.Now;
	}

	public Partie(long partieId, string titre, string systeme, string vtt, string applis, string description, byte nbPlacesTot, Statut statut, JdrUser meneur, List<JdrUser> joueurs, List<Seance> seances, List<Genre> genres)
	{
		PartieId = partieId;
		Titre = titre;
		Systeme = systeme;
		Vtt = vtt;
		Applis = applis;
		Description = description;
		NbPlacesTot = nbPlacesTot;
		Statut = statut;
		Meneur = meneur;
		MeneurId = meneur.Id;
		DateCreaPartie = DateTime.Now;
		Joueurs = joueurs;
		Genres = genres;
		Seances = seances;
	}

	public int NbPlacesRest
	{
		get
		{
			if (joueurs != null)
			{
				return nbPlacesTot - joueurs.Count();
			}
			return nbPlacesTot;
		}
	}


}
