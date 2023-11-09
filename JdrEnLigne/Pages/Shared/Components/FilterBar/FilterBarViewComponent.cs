using JdrEnLigne.Models;
using Microsoft.AspNetCore.Mvc;

namespace JdrEnLigne.Pages.Shared.Components.FilterBar
{
	public class FilterBarViewComponent : ViewComponent
	{
        public FilterBarViewComponent()
        {
        }
		public IViewComponentResult Invoke(Filter filter)
		{
			return View("Default", filter);
		}

	}
}
