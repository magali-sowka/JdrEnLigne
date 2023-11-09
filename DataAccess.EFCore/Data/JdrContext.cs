using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EFCore.Data;

public partial class JdrContext : IdentityDbContext<JdrUser>
{
	private readonly IConfiguration _config;
	public JdrContext(IConfiguration config)
	{
		_config = config;
	}

	public JdrContext(DbContextOptions<JdrContext> options, IConfiguration config)
		: base(options)
	{
		_config = config;
	}

	public virtual DbSet<Campagne> Campagnes { get; set; }

	public virtual DbSet<Genre> Genres { get; set; }

	public virtual DbSet<JdrUser> JdrUsers { get; set; }

	public virtual DbSet<Oneshot> Oneshots { get; set; }

	public virtual DbSet<Partie> Parties { get; set; }

	public virtual DbSet<Seance> Seances { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	=> optionsBuilder.UseSqlServer(_config["JdrEnLigne:ConnectionString"]);

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<JdrUser>(entity =>
		{
			entity.ToTable("JdrUser");

			entity.Property(e => e.Id)
				.HasColumnName("UserId");
			entity.Property(e => e.Pseudo)
				.IsRequired(true)
				.HasMaxLength(50);
			entity.Property(e => e.Presentation)
				.IsRequired(false);
			entity.Property(e => e.UrlAvatar)
				.IsRequired(false)
				.HasMaxLength(100);
			entity.Property(e => e.DateCreaCompte)
				.IsRequired(true)
				.HasColumnType("date");

			entity.HasMany(d => d.PartiesJoueur).WithMany(p => p.Joueurs)
				.UsingEntity<Dictionary<string, object>>(
					"JoueurPartie",
					r => r.HasOne<Partie>().WithMany()
						.HasForeignKey("PartieId")
						.OnDelete(DeleteBehavior.ClientSetNull),
					l => l.HasOne<JdrUser>().WithMany()
						.HasForeignKey("Id")
						.OnDelete(DeleteBehavior.ClientSetNull),
					j =>
					{
						j.HasKey("Id", "PartieId");
						j.ToTable("JoueurPartie");
						j.IndexerProperty<string>("Id").HasColumnName("UserId");
						j.IndexerProperty<long>("PartieId").HasColumnName("PartieId");
					});
		});

		modelBuilder.Entity<Partie>(entity =>
		{
			entity.ToTable("Partie");

			entity.Property(e => e.Titre)
				.IsRequired(true)
				.HasMaxLength(100);
			entity.Property(e => e.Systeme)
				.IsRequired(true)
				.HasMaxLength(25);
			entity.Property(e => e.Vtt)
				.IsRequired(true)
				.HasMaxLength(25);
			entity.Property(e => e.Applis)
				.IsRequired(false)
				.HasMaxLength(50);
			entity.Property(e => e.NbPlacesTot)
				.IsRequired(true);
			entity.Property(e => e.Statut)
				.IsRequired(true);
			entity.Property(e => e.DateCreaPartie)
				.IsRequired(true)
				.HasColumnType("datetime");
			entity.Property(e => e.MeneurId)
				.IsRequired(true);

			entity.HasOne(d => d.Meneur).WithMany(p => p.PartiesMeneur)
						.HasForeignKey(d => d.MeneurId)
						.OnDelete(DeleteBehavior.ClientSetNull);

			entity.HasMany(d => d.Genres).WithMany(p => p.Parties)
				.UsingEntity<Dictionary<string, object>>(
					"PartieGenre",
					r => r.HasOne<Genre>().WithMany()
						.HasForeignKey("GenreId")
						.OnDelete(DeleteBehavior.ClientSetNull),
					l => l.HasOne<Partie>().WithMany()
						.HasForeignKey("PartieId")
						.OnDelete(DeleteBehavior.ClientSetNull),
					j =>
					{
						j.HasKey("PartieId", "GenreId").HasName("PK_PartieGenre");
						j.ToTable("PartieGenre");
						j.IndexerProperty<long>("PartieId").HasColumnName("PartieId");
						j.IndexerProperty<short>("GenreId").HasColumnName("GenreId");
					});
		});

		modelBuilder.Entity<Campagne>(entity =>
		{
			entity.Property(e => e.Duree)
				.HasMaxLength(50)
				.IsRequired(true);
			entity.Property(e => e.Frequence)
				.HasMaxLength(50)
				.IsRequired(true);
		});

		modelBuilder.Entity<Genre>(entity =>
		{
			entity.HasKey(e => e.GenreId).HasName("PK_Genre");

			entity.ToTable("Genre");

			entity.Property(e => e.Libelle)
				.HasMaxLength(50)
				.IsRequired(true);
		});


		modelBuilder.Entity<Seance>(entity =>
		{
			entity.ToTable("Seance");

			entity.HasKey(e => e.SeanceId).HasName("PK_Seance");

			entity.Property(e => e.Debut)
				.HasColumnType("datetime")
				.IsRequired(true);
			entity.Property(e => e.Duree)
			.HasMaxLength(50)
				.IsRequired(true);
			entity.Property(e => e.Libelle)
				.HasMaxLength(50)
				.IsRequired(true);
			entity.Property(e => e.PartieId)
				.IsRequired(true);

			entity.HasOne(d => d.Partie).WithMany(p => p.Seances)
				.HasForeignKey(d => d.PartieId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		});

	}
}
