namespace Domain.Entities;

public partial class Seance
{
    private long seanceId;
    private string libelle;
    private DateTime debut;
    private string duree;
    private long partieId;
    private Partie partie;
    public long SeanceId
    {
        get { return seanceId; }
        private set { seanceId = value; }
    }

    public string Libelle
    {
        get { return libelle; }
        set { libelle = value; }
    }

    public DateTime Debut
    {
        get { return debut; }
        set { debut = Debut; }
    }

    public String Duree
    {
        get { return duree; }
        set { duree = value; }
    }

    public long PartieId
    {
        get { return partieId; }
        private set { partieId = value; }
    }

    public Partie Partie
    {
        get { return partie; }
        private set { partie = value; }
    }
}
