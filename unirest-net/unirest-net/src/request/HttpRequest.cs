using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

using unirest_net.http;

namespace unirest_net.request
{
    public class HttpRequest : BaseRequest
    {
        // Should add overload that takes URL object
        public HttpRequest(HttpMethod method, string url): base(method, url)
        {

        }
    }
}
