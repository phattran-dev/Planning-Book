using Planning_book.Domain.Constant;

namespace Planning_book.Domain
{
    public class PagingFilterCriteria
    {
        public int PageIndex { get; set; }
        public int NumberItemsPerPage { get; set; }
        public List<Tuple<string, SortDirection>> SortCriteria { get; set; }
        public string QueryText { get; set; }
    }
}
