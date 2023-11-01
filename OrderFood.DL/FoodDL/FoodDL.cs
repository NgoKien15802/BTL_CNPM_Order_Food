using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.FoodDL
{
    public class FoodDL : BaseDL<Food>, IFoodDL
    {
        public FoodDL(IConfiguration configuration) : base(configuration)
        {

        }


    }
}
