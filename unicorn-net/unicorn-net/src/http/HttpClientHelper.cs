using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Http;

using unicorn_net;
using unicorn_net.http;
using unicorn_net.request;

namespace unicorn_net.http
{
    public class HttpClientHelper
    {
        private const string USER_AGENT = "unicorn-java/1.0";
        private const int CONNECTION_TIMEOUT = 600000;
        private const int SOCKET_TIMEOUT = 600000;

        public static HttpResponse<T> Request<T>(BaseRequest request)
        {
            request.Headers.Add("user-agent", USER_AGENT);

            var client = new HttpClient();
            var msg = new HttpRequestMessage(request.HttpMethod, request.URL);

            foreach (var header in request.Headers)
            {
                msg.Headers.Add(header.Key, header.Value);
            }

            if (request is HttpRequestWithBody)
            {
                
            }
        }
    }
}
