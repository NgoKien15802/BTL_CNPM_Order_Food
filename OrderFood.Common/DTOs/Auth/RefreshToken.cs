using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.DTOs.Auth
{
    public class RefreshToken
    {
        /// <summary>
        ///     Mã token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Ngày tạo
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        ///     Thời hạn refresh token
        /// </summary>
        public DateTime Expires { get; set; }
    }
}
