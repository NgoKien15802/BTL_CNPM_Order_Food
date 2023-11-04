using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class CategoriesDL : BaseDL<Category>, ICategoriesDL
    {
        public CategoriesDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
