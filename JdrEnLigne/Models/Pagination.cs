namespace JdrEnLigne.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int StartPage { get; set; }
		public int EndPage { get; set; }
		public string Area { get; set; }
		public string Page { get; set; }
		public string Handler { get; set; }
		public string[] Filters { get; set; }
        public string DateSort { get; set; }

        public Pagination()
        {
        }

        public Pagination(string area, string page, string handler, int totalItems, int currentPage, int pageSize = 10, string dateSort = "date_desc", params string[] filter)
        {
            int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;

            Area = area;
            Page = page;
            Handler = handler;
            Filters = filter.ToArray();
            DateSort = dateSort;
        }
    }
}
