using OrderFood.Common.DTOs;
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

        public async Task<ServiceResponse<T>> Delete(Guid recordId)
        {
            bool records = await _baseDL.Delete(recordId);
            if (records)
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

        #region Methods
        public async Task<ServiceResponse<T>> GetAllRecord(string? recordId = "")
        {
            var records = await _baseDL.GetAllRecord(recordId);
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


        public async Task<ServiceResponse<T>> GetById(Guid recordId)
        {
            var records = await _baseDL.GetById(recordId);
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
