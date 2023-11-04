using OrderFood.Common.Models;
using OrderFood.BL;

namespace OrderFood.API.Controllers
{
    public class CategoriesController : BaseController<Category>
    {
        private ICategoriesBL _categoriesBL;

        public CategoriesController(ICategoriesBL categoriesBL) : base(categoriesBL)
        {
            _categoriesBL = categoriesBL;
        }
    }
}
