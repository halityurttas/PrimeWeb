using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimeWeb.Util.HttpUtils
{
    /// <summary>
    /// Generic HttpClient wrapper
    /// </summary>
    public class HttpClientWrapper
    {
        /// <summary>
        /// Recommend the client as static from
        /// https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request
        /// </summary>
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Post encoded form values and then read response
        /// </summary>
        /// <param name="url">Post url</param>
        /// <param name="values">Encoded string key value pair</param>
        /// <returns>Response as string</returns>
        public async Task<string> HttpPostAsync(string url, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = await httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Get url response data
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Response as string</returns>
        public async Task<string> HttpGetAsync(string url)
        {
            return await httpClient.GetStringAsync(url);
        }
    }
}
