using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class CategoriesBL : BaseBL<Category>, ICategoriesBL
    {

        private ICategoriesDL _categoriesDL;

        public CategoriesBL(ICategoriesDL categoriesDL) : base(categoriesDL)
        {
            _categoriesDL = categoriesDL;
        }
    }
}
