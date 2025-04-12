namespace motorsports_Domain.Pagination
{
    public class PaginationParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        private const int MaxPageSize = 50;

        public int Skip => (PageNumber - 1) * PageSize;

        public int Take => PageSize > MaxPageSize ? MaxPageSize : PageSize;
    }
}
