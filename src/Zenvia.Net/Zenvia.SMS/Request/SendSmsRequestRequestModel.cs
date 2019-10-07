using RestSharp;
using Zenvia.Models;
using Zenvia.SMS.Models.Requests;

namespace Zenvia.SMS.Request
{

    public class SendSmsRequestModel : RequestModel<SendSmsRequestPayload>
    {
        public SendSmsRequestModel(SendSmsRequestPayload model) : base(model)
        {
        }

        public override void Bind(IRestRequest request)
        {
            Validate();

            request.AddJsonBody(Data);
        }
    }
}
