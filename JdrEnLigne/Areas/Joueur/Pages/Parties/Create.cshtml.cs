using Domain.Entities;
using Domain.Interfaces;
using JdrEnLigne.Models.PageModels;
using JdrEnLigne.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JdrEnLigne.Areas.Joueur.Pages.Parties
{
    [Area("Joueur")]
    [Authorize(Roles = "Joueur")]
    public class CreateModel : CreateOrEditPartiePM
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<JdrUser> _userManager;

        public CreateModel(IUnitOfWork unitOfWork, UserManager<JdrUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [BindProperty]
        public PartieVM Partie { get; set; }
        //[BindProperty]
        //public Seance Seance { get; set; }

        public void OnGet()
        {
            Partie = new PartieVM();
            GetSelectedGenres(_unitOfWork, new Oneshot());
        }

        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            if (selectedGenres == null || selectedGenres.Length == 0)
            {
                ModelState.AddModelError("Partie.Genres", "Veuillez sélectionner au moins un thème.");

            }
            if (Partie.Format == Discriminator.Oneshot)
            {
                if (Partie.NbSeances <= 0)
                {
                    ModelState.AddModelError("Partie.NbSeances", "Veuillez indiquer le nombre estimé de séances.");
                }
            }
            if (Partie.Format == Discriminator.Campagne)
            {
                if (Partie.Duree == null)
                {
                    ModelState.AddModelError("Partie.Duree", "Veuiller donner une durée approximative de la campagne.");
                }
                if (Partie.Frequence == null)
                {
                    ModelState.AddModelError("Partie.Frequence", "Veuiller donner la fréquence des séances.");
                }
            }
            if (ModelState.IsValid)
            {
                Partie newPartie;
                JdrUser meneur = await _userManager.GetUserAsync(User);

                try
                {
                    if (Partie.Format == Discriminator.Oneshot)
                    {
                        newPartie = Partie.CreateOneshot(meneur);
                    }

                    else
                    {
                        newPartie = Partie.CreateCampagne(meneur);
                    }

                    await CreatePartieGenresAsync(selectedGenres, newPartie);

                    _unitOfWork.Parties.Add(newPartie);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToPage("/Parties/Index", "MeneurIndex", new { area = "Joueur" });
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur pendant la création de la partie : " + ex.Message);
                }
            }

            Oneshot o = new Oneshot();
            if (selectedGenres != null)
            {
                await CreatePartieGenresAsync(selectedGenres, o);
            }
            GetSelectedGenres(_unitOfWork, o);
            return Page();
        }

        private async Task CreatePartieGenresAsync(string[] selectedGenres, Partie partie)
        {
            if (selectedGenres.Length > 0)
            {
                partie.Genres = new List<Genre>();
                foreach (string id in selectedGenres)
                {
                    short genreId;
                    if (short.TryParse(id, out genreId))
                    {
                        Genre? genre = await _unitOfWork.Genres.GetByIdAsync(genreId);
                        if (genre != null)
                        {
                            partie.Genres.Add(genre);
                        }
                    }
                }
            }
        }
    }
}
