using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class BookBL : BaseBL<Book>, IBookBL
    {
        private IBookDL _bookDL;
        ServiceResponse<Book> _serviceResponse = new ServiceResponse<Book>();

        public BookBL(IBookDL bookDL) : base(bookDL)
        {
            this._bookDL = bookDL;
        }
    }
}
