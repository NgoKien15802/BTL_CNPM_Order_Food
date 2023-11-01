using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;
        ServiceResponse<T> _serviceResponse = new ServiceResponse<T>();


        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            this._baseDL = baseDL;
        }



        #endregion

        #region Methods
        public async Task<ServiceResponse<T>> GetAllRecord()
        {
            var records = await _baseDL.GetAllRecord();
            if (records != null)
            {
                _serviceResponse.Success = true;
                _serviceResponse.Data = records;
            }
            else
            {
                _serviceResponse.Success = false;
            }
            return _serviceResponse;
        }

        #endregion
    }
}
