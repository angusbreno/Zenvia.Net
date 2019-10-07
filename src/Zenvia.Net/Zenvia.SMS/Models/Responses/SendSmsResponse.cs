using System.Collections.Generic;

namespace Zenvia.SMS.Models.Responses
{
    public class SendSmsResponsePayload
    {
        public SendSmsResponse SendSmsResponse { get; set; }
    }

    public class SendSmsResponse
    {
        public string StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public string DetailCode { get; set; }

        public string DetailDescription { get; set; }

        public IEnumerable<SendSmsResponsePart> Parts { get; set; }

    }

    public class SendSmsResponsePart
    {
        public string PartId { get; set; }

        public string Order { get; set; }
    }
}
