namespace JAP_TASK_1_WEB_API.Models
{
    public class PagedResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? NextPage { get; set; } = null;
        public int? PreviousPage { get; set; } = null;
    }
}