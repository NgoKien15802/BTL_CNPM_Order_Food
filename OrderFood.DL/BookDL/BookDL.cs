using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class BookDL : BaseDL<Book>, IBookDL
    {
        IConfiguration _configuration;

        public BookDL(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
    }
}
