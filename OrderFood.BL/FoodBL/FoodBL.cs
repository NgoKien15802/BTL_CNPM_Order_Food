using OrderFood.Common.Models;
using OrderFood.DL;
using OrderFood.DL.FoodDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.FoodBL
{
    public class FoodBL : BaseBL<Food>, IFoodBL
    {
        private IFoodDL _foodDL;

        public FoodBL(IFoodDL foodDL) : base(foodDL)
        {
            _foodDL = foodDL;
        }
    }
}
