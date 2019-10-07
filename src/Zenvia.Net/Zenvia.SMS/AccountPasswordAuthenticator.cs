using RestSharp;
using RestSharp.Authenticators;

namespace Zenvia.SMS
{
    public class ApiTokenAuthenticator : IAuthenticator
    {
        private readonly ZenviaSMSClient zenviaSMSClient;

        public ApiTokenAuthenticator(ZenviaSMSClient zenviaSMSClient)
        {
            this.zenviaSMSClient = zenviaSMSClient;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {

            if (!string.IsNullOrEmpty(zenviaSMSClient.ApiToken))
            {
                request.AddHeader("Authorization", "Basic " + zenviaSMSClient.ApiToken);
            }

        }
    }


}
