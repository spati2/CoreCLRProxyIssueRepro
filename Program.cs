using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace HttpIssueRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = new WrapperStream(File.ReadAllBytes(@"TestFile.txt"));
            var httpMessageHandler = new HttpClientHandler();
            httpMessageHandler.Proxy = new WebProxy("127.0.0.1", 8888);
            httpMessageHandler.Proxy.Credentials = new NetworkCredential("1", "1");
            var httpClient = new HttpClient(httpMessageHandler);
            HttpRequestMessage message = new HttpRequestMessage();
            message.Content = new StreamContent(stream, 8192);
            message.RequestUri = new Uri("https://httpbin.org/put");
            message.Method = HttpMethod.Put;
            message.Content.Headers.ContentLength = stream.Length;
            var responseMessage = httpClient.SendAsync(message).Result;

        }
    }
}
