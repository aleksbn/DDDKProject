namespace DDDKHostAPI.Models
{
    public class RequestParams
    {
        const int maxPageSize = 5000;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value <= maxPageSize) ? value : maxPageSize;
            }
        }
    }
}
