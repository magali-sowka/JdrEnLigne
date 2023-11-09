namespace Domain.Entities;

public partial class Genre
{
	private short genreId;
	private string libelle;
	private ICollection<Partie>? parties;
	public short GenreId
	{
		get { return genreId; }
		private set { genreId = value; }
	}

	public string Libelle
	{
		get { return libelle; }
		set { libelle = value; }
	}

	public ICollection<Partie>? Parties
	{
		get { return parties; }
		set { parties = value; }
	}
}
