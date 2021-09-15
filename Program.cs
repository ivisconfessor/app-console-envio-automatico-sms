using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EnvioAutomaticoSMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escreva uma Mensagem...");

            string msg = Console.ReadLine();

            Console.WriteLine("Enviando SMS, aguarde por favor!");

            var messageSent = SendSMS(msg);

            if (messageSent.Status == MessageResource.StatusEnum.Accepted)
            {
                Console.WriteLine("SMS Enviado com Sucesso! => Mensagem Enviada: " + messageSent.Body);
            }
            else
            {
                Console.WriteLine("SMS Erro no Envio! => Erro: " + messageSent.ErrorMessage);
            }
        }

        static MessageResource SendSMS(string message) 
        {
            var accountSid = "[Busque o seu accountSid na plataforma do Twilio na área logada de sua conta]";  
            var authToken = "[Busque o seu authToken na plataforma do Twilio na área logada de sua conta]"; 
            TwilioClient.Init(accountSid,authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+55[DDD][NúmeroQueReceberáAMensagem]"));
            messageOptions.MessagingServiceSid = "[Busque o seu MessagingServiceSid na plataforma do Twilio na área logada de sua conta]";
            messageOptions.Body = message;

            return MessageResource.Create(messageOptions);
        }
    }
}
