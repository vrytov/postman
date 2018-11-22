using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public interface IMessageImplementation
    {
        IEnumerable<KeyValuePair<string, string>> Headers { get; }

        IEnumerable<string> From { get; }
        IEnumerable<string> To { get; }

        string Subject { get; }
        string TextBody { get; }
        string HtmlBody { get; }

        void WriteTo(Stream stream);
    }
}
