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
        }

        public PaginationQuery(int pageNumber, int pageSize, MediaType mediaType)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MediaType = mediaType;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public MediaType MediaType { get; set; }
    }
}