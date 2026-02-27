using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailMessageBuilder
{
    abstract class Builder
    {
        public abstract Builder SetFrom(string from);
        public abstract Builder SetTo(string to);
        public abstract Builder SetSubject(string subject);
        public abstract Builder SetBody(string body);
        public abstract MailMessage GetResult();
    }
}
