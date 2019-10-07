using Zenvia.Validation;

namespace Zenvia.SMS.Models.Requests
{
    public class SendSmsRequestPayload : IValidate
    {
        public SendSmsRequestPayload(SendSmsRequest sendSmsRequest)
        {
            SendSmsRequest = sendSmsRequest;
        }

        public SendSmsRequest SendSmsRequest { get; set; }

        public void Validate()
        {
            //validate
        }
    }

    public class SendSmsRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Schedule { get; set; }
        public string Msg { get; set; }
        public string CallbackOption { get; set; }
        public string Id { get; set; }
        public string AggregateId { get; set; }
        public bool FlashSms { get; set; }


    }
}
