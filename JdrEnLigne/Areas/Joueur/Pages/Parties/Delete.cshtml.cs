using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.EFCore.Data;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using JdrEnLigne.Models.ViewModels;
using Domain.Interfaces;

namespace JdrEnLigne.Areas.Joueur.Pages.Parties
{
    [Area("Joueur")]
    [Authorize(Roles = "Joueur")]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync(long? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			Partie? partie = await _unitOfWork.Parties.GetAsync(p => p.PartieId == id);

			if (partie == null)
			{
				return NotFound();
			}

            _unitOfWork.Parties.Remove(partie);
			await _unitOfWork.CompleteAsync();
            return RedirectToPage("/Parties/Index", "MeneurIndex", new { area = "Joueur" });
		}
    }
}
