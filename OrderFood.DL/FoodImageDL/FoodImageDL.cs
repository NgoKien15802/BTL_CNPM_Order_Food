using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.FoodImageDL
{
    public class FoodImageDL : BaseDL<FoodImage>, IFoodImageDL
    {
        public FoodImageDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
