using Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JdrEnLigne.Models.ViewModels
{
	public enum Discriminator
	{
		[Description("Oneshot")]
		Oneshot, 
		[Description("Campagne")]
		Campagne
	}
	public class PartieVM
	{
		private long partieId;
		private string titre;
		private string systeme;
		[Required]
		[StringLength(50)]
		private string vtt;
		private string? applis;
		private ICollection<Genre> genres = new List<Genre>();
		private string? description;
		private byte nbPlacesTot = 1;
		private int nbPlacesRest;
		private Statut statut;
		private Discriminator format;
		private byte? nbSeances = 1;
		private string? duree;
		private string? frequence;
		private DateTime dateCreaPartie;
		private string meneurID;
		private JdrUser meneur;
		private DateTime? prochaineSeance; 

		public long PartieId
		{
			get { return partieId; }
			set { partieId = value; }
		}

		[Required(ErrorMessage = "Entrez un titre")]
		[StringLength(100,MinimumLength = 3, ErrorMessage = "La longueur du titre doit être comprise entre 3 et 100 caractères")]
		public string Titre
		{
			get { return titre; }
			set { titre = value; }
		}

		[Required(ErrorMessage = "Entrez le nom d'un système de jeu")]
		[StringLength(25, MinimumLength = 3, ErrorMessage = "La longueur du nom du système de jeu doit être comprise entre 3 et 25 caractères")]
		[Display(Name = "Système de jeu")]
		public string Systeme
		{
			get { return systeme; }
			set { systeme = value; }
		}

		[Required(ErrorMessage = "Entrez le nom d'un table virtuelle")]
		[StringLength(25, MinimumLength = 3, ErrorMessage = "La longueur du nom de la table virtuelle doit être comprise entre 3 et 25 caractères")]
		[Display(Name = "Table virtuelle")]
		public string Vtt
		{
			get { return vtt; }
			set { vtt = value; }
		}

		[StringLength(50, MinimumLength = 3, ErrorMessage = "La longueur de la liste des noms des autres applications utilisées doit être comprise entre 3 et 50 caractères")]
		[Display(Name = "Autres applications")]
		public string? Applis
		{
			get { return applis; }
			set { applis = value; }
		}

		[ValidateNever]
		/* Utilisé pour l'affichage */
		public ICollection<Genre> Genres
		{
			get { return genres; }
			set { genres = value; }
		}

		[Required(ErrorMessage = "Entrez une description de la partie")]
		public string? Description
		{
			get { return description; }
			set { description = value; }
		}

		[Required(ErrorMessage = "Entrez le nombre maximal de joueurs pour cette partie")]
		[Display(Name = "Nombre de places total")]
		[Range(1, 10, ErrorMessage = "Le nombre de joueur doit être compris entre 1 et 10")]
		public byte NbPlacesTot
		{
			get { return nbPlacesTot; }
			set { nbPlacesTot = value; }
		}

		[ValidateNever]
		/* Utilisé pour l'affichage */
		public int NbPlacesRest
		{
			get { return nbPlacesRest; }
			set { nbPlacesRest = value; }
		}


		[DisplayFormat(DataFormatString = "statut.GetEnumDescription()" )]
		public Statut Statut
		{
			get { return statut; }
			set { statut = value; }
		}

		[Required(ErrorMessage = "Veuillez choisir le format de la partie")]
		public Discriminator Format
		{
			get { return format; }
			set { format = value; }
		}

		[Display(Name = "Nombre de séances estimé")]
		public byte? NbSeances
		{
			get { return nbSeances; }
			set { nbSeances = value; }
		}

		[StringLength(50, MinimumLength = 3, ErrorMessage = "L'estimation de la durée de la campagne a une longueur comprise entre 3 et 50 caractères")]
		[Display(Name = "Durée estimée de la campagne")]
		public string? Duree
		{
			get { return duree; }
			set { duree = value; }
		}

		[StringLength(50, MinimumLength = 3, ErrorMessage = "L'estimation de la fréquence des séances a une longueur comprise entre 3 et 50 caractères")]
		[Display(Name = "Fréquence des parties")]
		public string? Frequence
		{
			get { return frequence; }
			set { frequence = value; }
		}

		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
		public DateTime DateCreaPartie
		{
			get { return dateCreaPartie; }
		}

		[ValidateNever]
		/* Utilisé pour l'affichage */
		public string MeneurID
		{
			get { return meneurID; }
		}

		[ValidateNever]
		/* Utilisé pour l'affichage */
		public JdrUser Meneur
		{
			get { return meneur; }
		}

		[ValidateNever]
		/* Utilisé pour l'affichage */
		public DateTime? ProchaineSeance
		{
			get { return prochaineSeance;}
		}

		public PartieVM()
		{
		}

		public PartieVM(Oneshot oneshot)
		{
			this.InitPartieVM(oneshot);
			this.Format = Discriminator.Oneshot;
			this.NbSeances = oneshot.NbSeances;
		}

		public PartieVM(Campagne campagne)
		{
			this.InitPartieVM(campagne);
			this.Format = Discriminator.Campagne;
			this.Duree = campagne.Duree;
			this.Frequence = campagne.Frequence;
		}

		private void InitPartieVM(Partie partie)
		{
			this.PartieId = partie.PartieId;
			this.Titre = partie.Titre;
			this.Systeme = partie.Systeme;
			this.Vtt = partie.Vtt;
			this.Applis = partie.Applis;
			this.Genres = partie.Genres;
			this.Description = partie.Description;
			this.NbPlacesTot = partie.NbPlacesTot;
			this.NbPlacesRest = partie.NbPlacesRest;
			this.Statut = partie.Statut;
			this.dateCreaPartie = partie.DateCreaPartie;
			this.meneurID = partie.MeneurId;
			this.meneur = partie.Meneur;
			if(partie.Seances.Any())
			{
				DateTime now = DateTime.Now;
				List<DateTime> seances = partie.Seances.Select(s => s.Debut).ToList();
				List<DateTime> prochainesSeances = seances.ToList().FindAll(s => s >= now);
				this.prochaineSeance = prochainesSeances.Min();
			}
			else
			{
				prochaineSeance = null;
			}
		}

		public Oneshot CreateOneshot(JdrUser user)
		{
			Oneshot oneshot = new Oneshot();
			oneshot.Titre = this.Titre;
			oneshot.Systeme = this.Systeme;
			oneshot.Vtt = this.Vtt;
			oneshot.Applis = this.Applis;
			oneshot.Description = this.Description;
			oneshot.NbPlacesTot = this.NbPlacesTot;
			oneshot.NbSeances = (byte)this.NbSeances;
			oneshot.Statut = this.Statut;
			oneshot.Meneur = user;
			oneshot.MeneurId = user.Id;
			oneshot.DateCreaPartie = DateTime.Now;

			return oneshot;
		}

		public Campagne CreateCampagne(JdrUser user)
		{
			Campagne campagne = new Campagne();
			campagne.Titre = this.Titre;
			campagne.Systeme = this.Systeme;
			campagne.Vtt = this.Vtt;
			campagne.Applis = this.Applis;
			campagne.Description = this.Description;
			campagne.NbPlacesTot = this.NbPlacesTot;
			campagne.Duree = this.Duree;
			campagne.Frequence = this.Frequence;
			campagne.Statut = this.Statut;
			campagne.Meneur = user;
			campagne.MeneurId = user.Id;
			campagne.DateCreaPartie = DateTime.Now;

			return campagne;
		}

		public unsafe void UpdateOneshot(Oneshot* o)
		{
			(*o).Titre = this.Titre;
			(*o).Systeme = this.Systeme;
			(*o).Vtt = this.Vtt;
			(*o).Applis = this.Applis;
			(*o).Description = this.Description;
			(*o).NbPlacesTot = this.NbPlacesTot;
			(*o).NbSeances = (byte)this.NbSeances;
			(*o).Statut = this.Statut;
		}

		public unsafe void UpdateCampagne(Campagne* c)
		{
			(*c).Titre = this.Titre;
			(*c).Systeme = this.Systeme;
			(*c).Vtt = this.Vtt;
			(*c).Applis = this.Applis;
			(*c).Description = this.Description;
			(*c).NbPlacesTot = this.NbPlacesTot;
			(*c).Duree = this.Duree;
			(*c).Frequence = this.Frequence;
			(*c).Statut = this.Statut;
		}
	}
}
