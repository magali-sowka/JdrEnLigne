using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JdrEnLigne.Models.PageModels
{
	[Area("Joueur")]
	[Authorize(Roles = "Joueur")]
	public class IndexPartiePM : PageModel
	{
		public List<SelectListItem> PageSizesList { get; set; }

		public void GetPageSizes(int pageSize, string dateSort, string[] filter)
		{
			PageSizesList = new List<SelectListItem>
			{
				new SelectListItem
				{
					Text = "10",
					Value = @Url.Page("/Parties/Index", "MeneurIndex", new { area = "Joueur", dateSort = dateSort, filter = filter, pageSize = 10 }),
					Selected = (pageSize == 10) ? true : false
				},
				new SelectListItem
				{
					Text = "25",
					Value = @Url.Page("/Parties/Index", "MeneurIndex", new { area = "Joueur", dateSort = dateSort, filter = filter, pageSize = 25 }),
					Selected = (pageSize == 25) ? true : false
				},
				new SelectListItem
				{
					Text = "50",
					Value = @Url.Page("/Parties/Index", "MeneurIndex", new { area = "Joueur", dateSort = dateSort, filter = filter, pageSize = 50 }),
					Selected = (pageSize == 50) ? true : false
				},
				new SelectListItem
				{
					Text = "100",
					Value = @Url.Page("/Parties/Index", "MeneurIndex", new { area = "Joueur", dateSort = dateSort, filter = filter, pageSize = 100 }),
					Selected = (pageSize == 100) ? true : false
				}
			};
		}
	}
}