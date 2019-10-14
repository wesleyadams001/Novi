using KeepaModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Tools
{
    public class Client
    {
        private HttpClient httpClient;

        /// <summary>
        /// Downloads the url request async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> DownloadAsync(string request)
        {
            //Download async
            var t = await this.httpClient.GetStringAsync(request);
            return t;

        }

        /// <summary>
        /// Initializes the custom httpclient with automatic decompression with Deflate or Gzip
        /// accepting json format
        /// </summary>
        public Client()
        {
            //Define the HttpClient with Automatic decompression with Gzip
            this.httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip });

            //Specify utilizing json
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
