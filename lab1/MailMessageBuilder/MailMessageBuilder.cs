using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailMessageBuilder
{
    class MailMessageConcreteBuilder : Builder
    {
        private MailMessage message = new MailMessage();

        public override Builder SetFrom(string from)
        {
            message.From = from;
            return this;
        }

        public override Builder SetTo(string to)
        {
            message.To = to;
            return this;
        }

        public override Builder SetSubject(string subject)
        {
            message.Subject = subject;
            return this;
        }

        public override Builder SetBody(string body)
        {
            message.Body = body;
            return this;
        }

        public override MailMessage GetResult()
        {
            return message;
        }
    }
}
