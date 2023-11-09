namespace JdrEnLigne.Models
{
    public class Search
    {
		public string SearchText { get; set; }
        public string Method { get; set; }
		public string Area { get; set; }
		public string Page { get; set; }
		public string Handler { get; set; }


		public Search() { }

        public Search(string area, string page, string handler, string method, string searchText)
        {
            SearchText = searchText;
            Method = method;
            Area = area;
            Page = page;
            Handler = handler;
        }

        

    }
}
