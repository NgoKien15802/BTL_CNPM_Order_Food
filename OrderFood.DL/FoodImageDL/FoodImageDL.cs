using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class FoodImageDL : BaseDL<FoodImage>, IFoodImageDL
    {
        public FoodImageDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
