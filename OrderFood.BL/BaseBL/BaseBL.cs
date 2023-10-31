using OrderFood.DL;

namespace OrderFood.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            this._baseDL = baseDL;
        }

        #endregion

        #region Methods

        #endregion
    }
}
