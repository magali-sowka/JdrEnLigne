using JdrEnLigne.Models;
using Microsoft.AspNetCore.Mvc;

namespace JdrEnLigne.Pages.Shared.Components.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
	{
		public SearchBarViewComponent() { }

		public IViewComponentResult Invoke (Search search)
		{
			return View("Default", search);
		}
	}
}
