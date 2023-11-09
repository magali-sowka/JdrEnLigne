using Domain.Entities;
using JdrEnLigne.Models.ViewModels;

namespace JdrEnLigne.Models
{

	public class Filter
	{
		public List<SelectedGenre> Genres { get; set; }
		public List<SelectedFormat> Formats { get; set; }
		public List<SelectedStatut> Statuts { get; set; }

		public string Area { get; set; }
		public string Page { get; set; }
		public string Handler { get; set; }

		public Filter(string area, string page, string handler, IQueryable<Partie> parties, List<short> selectedGenres, List<Discriminator> selectedFormats, List<Statut> selectedStatuts)
		{
			this.Area = area;
			this.Page = page;
			this.Handler = handler;

			List<int> genreIds = new List<int>();
			List<int> intStatuts = new List<int>();
			List<int> intFormats = new List<int>();

			List<SelectedGenre> genres = new List<SelectedGenre>();
			List<SelectedFormat> formats = new List<SelectedFormat>();
			List<SelectedStatut> statuts = new List<SelectedStatut>();

			foreach (Partie partie in parties)
			{
				if (partie.GetType() == typeof(Oneshot) && !intFormats.Contains((int)Discriminator.Oneshot))
				{
					intFormats.Add((int)Discriminator.Oneshot);
					formats.Add(new SelectedFormat(Discriminator.Oneshot, selectedFormats.Contains(Discriminator.Oneshot)));
				}

				if (partie.GetType() == typeof(Campagne) && !intFormats.Contains((int)Discriminator.Campagne))
				{
					intFormats.Add((int)Discriminator.Campagne);
					formats.Add(new SelectedFormat(Discriminator.Campagne, selectedFormats.Contains(Discriminator.Campagne)));
				}

				foreach (Genre genre in partie.Genres)
				{
					if (!genreIds.Contains(genre.GenreId))
					{
						genreIds.Add(genre.GenreId);
						genres.Add(new SelectedGenre(genre.GenreId, genre.Libelle, selectedGenres.Contains(genre.GenreId)));
					}
				}

				if (!intStatuts.Contains((int)partie.Statut))
				{
					intStatuts.Add((int)partie.Statut);
					statuts.Add(new SelectedStatut(partie.Statut, selectedStatuts.Contains(partie.Statut)));
				}
			}

			Genres = genres.OrderBy(g => g.Libelle).ToList();
			Statuts = statuts.OrderBy(s => (int)s.Statut).ToList();
			Formats = formats.OrderBy(f => f.Format.GetEnumDescription()).ToList();
		}
	}
}
