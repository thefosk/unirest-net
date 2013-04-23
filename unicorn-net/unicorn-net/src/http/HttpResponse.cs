using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace unicorn_net.http
{
    public class HttpResponse<T>
    {
        private Stream raw;

        public int Code { get; private set; }
        public Dictionary<String, String> Headers { get; private set; }
        public T Body { get; set; }
    }
}
