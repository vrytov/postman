using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public byte[] Content { get; set; }
    }
}
