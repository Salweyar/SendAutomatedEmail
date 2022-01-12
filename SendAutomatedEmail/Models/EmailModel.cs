using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendAutomatedEmail.Models
{
    public class EmailModel
    {
        #nullable enable
        #nullable disable warnings

        public string EmailFrom { get; set; }

        public string EmailFromName { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public string[] Recipients { get; set; } = new string[] { };

        public string[] BCCs { get; set; } = new string[] { };

        public string[] CCs { get; set; } = new string[] { };

        #nullable disable
        #nullable enable warnings

    }
}
