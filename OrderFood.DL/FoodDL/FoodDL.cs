using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class FoodDL : BaseDL<Food>, IFoodDL
    {
        public FoodDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
