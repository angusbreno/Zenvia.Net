# Zenvia.Net
Zenvia is a communication platform focused in send sms, whatsapp messages and other.

## Zenvia.Net is a client

## HOW TO USE
```csharp
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
                To = "1321312312",
                Msg = "teste"
            };

            var r = await smsClient.SendMessageAsync(simpleMessage);

        }
        catch (SendSMSException e)
        {
            var q = e.Response;
            throw e;
        }




    }
}
```
