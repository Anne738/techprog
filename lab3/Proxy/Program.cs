using System;
using System.Collections.Generic;

namespace ProxyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebServer proxy = new ProxyServer();

            Console.WriteLine(proxy.GetPage("google.com"));
            Console.WriteLine(proxy.GetPage("google.com"));
            Console.WriteLine(proxy.GetPage("openai.com"));

            Console.Read();
        }
    }

    interface IWebServer
    {
        string GetPage(string url);
    }

    // RealSubject
    class WebServer : IWebServer
    {
        public string GetPage(string url)
        {
            return $"Web page from server: {url}";
        }
    }

    // Proxy
    class ProxyServer : IWebServer
    {
        private WebServer webServer = new WebServer();
        private Dictionary<string, string> cache = new Dictionary<string, string>();

        public string GetPage(string url)
        {
            if (cache.ContainsKey(url))
            {
                return $"From cache: {cache[url]}";
            }
            else
            {
                string page = webServer.GetPage(url);
                cache[url] = page;
                return page;
            }
        }
    }
}