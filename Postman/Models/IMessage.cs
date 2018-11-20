using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    internal interface IMessage
    {
        IEnumerable<KeyValuePair<string, string>> Headers { get; set; }

        IEnumerable<string> From { get; set; }
        IEnumerable<string> To { get; set; }

        string Subject { get; set; }
        string Content { get; set; }
        string Html { get; set; }

        void WriteTo(Stream stream);
    }
}
