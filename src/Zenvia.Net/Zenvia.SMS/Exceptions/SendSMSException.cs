using System;
using System.Runtime.Serialization;
using Zenvia.SMS.Models.Responses;

namespace Zenvia.SMS.Exceptions
{
    public class SendSMSException : Exception
    {
        public SendSmsResponse Response { get; set; }

        public SendSMSException()
        {
        }

        public SendSMSException(string message, SendSmsResponse response = null) : base(message)
        {
            Response = response;
        }

        public SendSMSException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SendSMSException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
