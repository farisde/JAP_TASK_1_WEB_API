using MovieBuff.Models;

namespace MovieBuff.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 10;
            MediaType = MediaType.Movie;
            SearchPhrase = null;
        }

        public PaginationQuery(int pageNumber, int pageSize, MediaType mediaType, string searchPhrase = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MediaType = mediaType;
            SearchPhrase = searchPhrase;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public MediaType MediaType { get; set; }
        public string SearchPhrase { get; set; }
    }
}