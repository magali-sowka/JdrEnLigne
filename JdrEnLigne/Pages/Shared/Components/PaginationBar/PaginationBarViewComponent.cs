using JdrEnLigne.Models;
using Microsoft.AspNetCore.Mvc;

namespace JdrEnLigne.Pages.Shared.Components.SearchBar
{
    public class PaginationBarViewComponent : ViewComponent
	{
		public PaginationBarViewComponent() { }

		public IViewComponentResult Invoke(Pagination pages)
		{
			return View("Default", pages);
		}
	}
}
