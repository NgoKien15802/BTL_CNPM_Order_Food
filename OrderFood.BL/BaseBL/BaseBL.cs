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

        public ServiceResponse<T> Add(T record)
        {
            int numberEmployeeOfAffected = _baseDL.Add(record);
            if (numberEmployeeOfAffected > 0)
            {
                _serviceResponse.Success = true;
                _serviceResponse.Data = 1;
            }
            else
            {
                _serviceResponse.Success = false;
                _serviceResponse.Data = 0;
            }
            return _serviceResponse;
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
                _serviceResponse.Data = records;
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
                _serviceResponse.Data = null;
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
                _serviceResponse.Data = null;
            }
            return _serviceResponse;
        }
        public ServiceResponse<T> Update(T record)
        {
            int numberEmployeeOfAffected = _baseDL.Update(record);
            if (numberEmployeeOfAffected > 0)
            {
                _serviceResponse.Success = true;
                _serviceResponse.Data = 1;
            }
            else
            {
                _serviceResponse.Success = false;
                _serviceResponse.Data = 0;
            }
            return _serviceResponse;
        }

        #endregion
    }
}
