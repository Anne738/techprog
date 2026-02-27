using System;

namespace MailMessageBuilder
{
    class MailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void Show()
        {
            Console.WriteLine("Від: " + From);
            Console.WriteLine("Кому: " + To);
            Console.WriteLine("Заголовок: " + Subject);
            Console.WriteLine("Повідомлення: " + Body);
        }
    }
}