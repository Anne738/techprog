using System;

namespace AdapterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Email
            MessageSender emailSender = new MessageSender();
            emailSender.Send("Hello!", "user@email.com");

            // SMS
            MessageSender smsSender = new SMSAdapter();
            smsSender.Send("Hello from SMS!", "+380991234567");

            // Telegram
            MessageSender telegramSender = new TelegramAdapter();
            telegramSender.Send("Hello from Telegram!", "@username");

            Console.Read();
        }
    }

    // Target
    class MessageSender
    {
        public virtual void Send(string message, string recipient)
        {
            Console.WriteLine($"Email sent to {recipient}: {message}");
        }
    }

    // Adaptee (SMS)
    class SMSsender
    {
        public void SendSMS(string message, string phoneNumber)
        {
            Console.WriteLine($"SMS sent to {phoneNumber}: {message}");
        }
    }

    // Adaptee (Telegram)
    class TelegramSender
    {
        public void SendTelegram(string message, string username)
        {
            Console.WriteLine($"Telegram message sent to {username}: {message}");
        }
    }

    // Adapter для SMS
    class SMSAdapter : MessageSender
    {
        private SMSsender sms = new SMSsender();

        public override void Send(string message, string recipient)
        {
            sms.SendSMS(message, recipient);
        }
    }

    // Adapter для Telegram
    class TelegramAdapter : MessageSender
    {
        private TelegramSender telegram = new TelegramSender();

        public override void Send(string message, string recipient)
        {
            telegram.SendTelegram(message, recipient);
        }
    }
}