using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public interface IBillDL : IBaseDL<Bill>
    {
        public List<Bill> GetBills();
    }
}
