using RestSharp;
using System;
using System.Threading.Tasks;
using Zenvia.SMS.Exceptions;
using Zenvia.SMS.Models.Requests;
using Zenvia.SMS.Models.Responses;
using Zenvia.SMS.Request;
using Zenvia.SMS.Serializers;

namespace Zenvia.SMS
{
    //https://zenviasms.docs.apiary.io/#reference/servicos-da-api/consulta-status-de-um-sms/testar-envio-de-um-unico-sms
    public class ZenviaSMSClient : ZenviaClient
    {
        public string ApiToken { get; set; }

        public RestClient RestClient;

        private JsonNetSerializer Serializer;

        public ZenviaSMSClient() : this(null, null)
        {

        }

        public ZenviaSMSClient(string apiToken) : this(apiToken, new Uri("https://api-rest.zenvia.com/"))
        {

        }

        public ZenviaSMSClient(string apiToken, Uri uri)
        {
            ApiToken = apiToken;

            Serializer = new JsonNetSerializer();

            RestClient = new RestClient(uri)
            {
                Authenticator = new ApiTokenAuthenticator(this)
            };

            RestClient.UseSerializer(() => Serializer);
            RestClient.AddDefaultHeader("Content-Type", "application/json");
        }


        private void ThrowResponseException(IRestResponse r)
        {

            string msg = r.ErrorMessage;
            SendSmsResponsePayload ro = null;

            try
            {
                if (!string.IsNullOrEmpty(r.Content))
                {
                    msg = r.StatusCode + " - " + r.Content;

                    ro = Serializer.Deserialize<SendSmsResponsePayload>(r);
                    if (ro?.SendSmsResponse != null)
                    {
                        msg = ro.SendSmsResponse.StatusCode + ro.SendSmsResponse.StatusDescription;
                    }
                }
            }
            finally
            {
                throw new SendSMSException(msg, ro?.SendSmsResponse);
            }

        }

        public async virtual Task<SendSmsResponse> SendMessageAsync(SendSmsRequest message)
        {
            var request = new RestRequest("services/send-sms", Method.POST);

            var requestModel = new SendSmsRequestModel(new SendSmsRequestPayload(message));
            requestModel.Bind(request);

            var s = Serializer.Serialize(requestModel.Data);

            var response = await RestClient.ExecuteTaskAsync<SendSmsResponsePayload>(request);

            if (!response.IsSuccessful)
            {
                ThrowResponseException(response);
            }

            return response.Data?.SendSmsResponse;
        }


    }


}
