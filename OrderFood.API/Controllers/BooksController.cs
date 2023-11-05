using Microsoft.AspNetCore.Mvc;
using OrderFood.BL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class BooksController : BaseController<Book>
    {
        private IBookBL _bookBL;

        public BooksController(IBookBL bookBL) : base(bookBL)
        {
            _bookBL = bookBL;
        }
    }
}
