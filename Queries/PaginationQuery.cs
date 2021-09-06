namespace JAP_TASK_1_WEB_API.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            // PageNumber = 1;
            // PageSize = 1;
            // IsMovie = true;
        }

        public PaginationQuery(int pageNumber, int pageSize, bool contentType)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            IsMovie = contentType;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsMovie { get; set; } = true;
    }
}