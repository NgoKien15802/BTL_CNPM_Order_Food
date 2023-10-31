namespace OrderFood.Common.DTOs
{
    public class PagingReponse<T>
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
