namespace OrderFood.Common.DTOs
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
