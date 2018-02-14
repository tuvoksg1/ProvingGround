using IdentityModel.Client;

namespace DynamicContainer
{
    internal static class ApiHelper
    {
        internal static string FormatUrl(string rootUrl)
        {
            const string slash = "/";

            if (!string.IsNullOrWhiteSpace(rootUrl) && !rootUrl.EndsWith(slash))
            {
                rootUrl = $"{rootUrl}{slash}";
            }

            return rootUrl;
        }

        internal static TokenResponse GetUserToken(RemoteRuntimeSettings settings, string userName, string password, string passportUrl = null)
        {
            if (string.IsNullOrWhiteSpace(passportUrl))
            {
                passportUrl = settings.PassportServerUrl;
            }

            passportUrl = FormatUrl(passportUrl);

            var client = new TokenClient(
                $"{passportUrl}core/connect/token",
                settings.PledgeJobClient,
                settings.PledgeJobSecret);

            return client.RequestResourceOwnerPasswordAsync(userName, password, settings.PledgeApiScope).Result;
        }
    }
}
