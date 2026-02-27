using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailMessageBuilder
{
    class Director
    {
        public MailMessage Construct(
            Builder builder,
            string from,
            string to,
            string subject,
            string body)
        {
            return builder
                .SetFrom(from)
                .SetTo(to)
                .SetSubject(subject)
                .SetBody(body)
                .GetResult();
        }
    }
}
