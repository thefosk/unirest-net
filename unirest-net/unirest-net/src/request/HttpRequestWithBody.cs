using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

using unirest_net.http;
using unirest_net.request;
using unirest_net.request;

namespace unirest_net.request
{
    public class HttpRequestWithBody : HttpRequest
    {
        public Stream Body { get; private set; }

        // Should add overload that takes URL object
        public HttpRequestWithBody(HttpMethod method, string url) : base(method, url)
        {
        }
    }
}
