namespace Entity.Requests
{
    /// <summary>
    /// Request containing the refresh token used to renew the access token.
    /// </summary>
    public class RenewTokenRequest
    {

        /// <summary>
        /// Refresh token used to obtain a new access token when the current one expires
        /// </summary>
        public string Token { get; set; } = string.Empty;

    }
}
