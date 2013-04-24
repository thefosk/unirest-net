using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Http;
using System.Threading.Tasks;
using unirest_net;
using unirest_net.http;
using unirest_net.request;

namespace unirest_net.http
{
    public class HttpClientHelper
    {
        private const string USER_AGENT = "unirest-java/1.0";

        public static HttpResponse<T> Request<T>(BaseRequest request)
        {
            if (!request.Headers.ContainsKey("user-agent"))
            {
                request.Headers.Add("user-agent", USER_AGENT);
            }

            var client = new HttpClient();
            var msg = new HttpRequestMessage(request.HttpMethod, request.URL);

            foreach (var header in request.Headers)
            {
                msg.Headers.Add(header.Key, header.Value);
            }

            if (request is HttpRequestWithBody)
            {
                msg.Content = new StreamContent((request as HttpRequestWithBody).Body);
            }

            var responseTask = client.SendAsync(msg);
            Task.WaitAll(responseTask);
            var response = responseTask.Result;

            return new HttpResponse<T>(response);
        }
    }
}
