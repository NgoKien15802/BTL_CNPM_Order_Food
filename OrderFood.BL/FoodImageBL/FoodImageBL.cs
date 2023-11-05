using OrderFood.Common.Models;
using OrderFood.DL;
using OrderFood.DL.FoodImageDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.FoodImageBL
{
    public class FoodImageBL : BaseBL<FoodImage>, IFoodImageBL
    {
        private IFoodImageDL _foodImageDL;

        public FoodImageBL(IFoodImageDL foodImageDL) : base(foodImageDL)
        {
            _foodImageDL = foodImageDL;
        }
    }
}