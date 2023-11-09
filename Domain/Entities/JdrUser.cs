using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public partial class JdrUser : IdentityUser
{
	private string pseudo;
	private string? presentation;
	private string urlAvatar;
	private DateTime dateCreaCompte;
	private ICollection<Partie>? partiesMeneur;
	private ICollection<Partie>? partiesJoueur;

	public string Pseudo
	{
		get { return pseudo; }
		set { pseudo = value; }
	}

	public string? Presentation
	{
		get { return presentation; }
		set { presentation = value; }
	}

	public string UrlAvatar
	{
		get { return urlAvatar; }
		set { urlAvatar = value; }
	}

	public DateTime DateCreaCompte
	{
		get { return dateCreaCompte; }
		set { dateCreaCompte = value; }
	}

	public ICollection<Partie>? PartiesMeneur
	{
		get { return partiesMeneur; }
		set { partiesMeneur = value; }
	}

	public ICollection<Partie>? PartiesJoueur
	{
		get { return partiesJoueur; }
		set { partiesJoueur = value; }
	}
}
