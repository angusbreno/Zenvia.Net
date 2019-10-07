using System;
using System.Threading.Tasks;
using Zenvia.SMS;
using Zenvia.SMS.Models.Requests;

namespace Zenvia.ConsolePlay
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        private static async Task Run()
        {
            try
            {
                var smsClient = new ZenviaSMSClient("#yourapikey");

                var simpleMessage = new SendSmsRequest()
                {
                    To = "5541997097084",
                    Msg = "teste"
                };

                var r = await smsClient.SendMessageAsync(simpleMessage);

            }
            catch (Exception e)
            {

                throw e;
            }




        }
    }
}
