using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;


namespace WindowsApp2.Services

{
    public static class NetworkService
    {
        #region Private fields and constants

        private const string URI_STRING = "http://gravitas-api.herokuapp.com/api/events/name?q=";
        private const string WP_USER_AGENT = "Mozilla/5.0 (Mobile; Windows Phone 8.1; Android 4.0; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 520) like iPhone OS 7_0_3 Mac OS X AppleWebKit/537 (KHTML, like Gecko) Mobile Safari/537";
        private static readonly HttpClient _httpClient;

        #endregion

        #region Private Helper Methods and Constructor

        private static async Task<Response<string>> GetRootResponseAsync(HttpResponseMessage httpResponse)
        {
            string content = null;
            StatusCode statusCode;

            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.Ok:
                    content = await httpResponse.Content.ReadAsStringAsync();
                    statusCode = StatusCode.Success;
                    break;
                default:
                    statusCode = StatusCode.ServerError;
                    break;
            }

            return new Response<string>(statusCode, content);
        }

        private static Response<string> Format(this Response<string> response)
        {
            if (response.Code != StatusCode.Success)
                return new Response<string>(response.Code, null);
            else
                return response;
        }

        private static async Task<Response<string>> GetResponseAsync(/*string currentDataVersion*/)
        {
            Response<string> response;
            try
            {
                /*
                var postContent = new HttpFormUrlEncodedContent(
                                    new KeyValuePair<string, string>[3] {
                                        new KeyValuePair<string, string>("username", "vinay"),
                                        new KeyValuePair<string, string>("password", "pass"),
                                        new KeyValuePair<string, string>("data_version", currentDataVersion)
                                    });
                */

                HttpResponseMessage httpResponse = await _httpClient.GetAsync(new Uri(URI_STRING));
                response = await GetRootResponseAsync(httpResponse);
            }
            catch
            {
                response = new Response<string>(StatusCode.NoInternet, null);
            }
            return response.Format();
        }

        static NetworkService()
        {
            // Prevent caching of data locally to avoid errors and ensure fresh data on every request.
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
            filter.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;

            _httpClient = new HttpClient(filter);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(WP_USER_AGENT);
        }

        #endregion

        #region Public Methods (API)

        /// <summary>
        /// Get the data as a Json string along with status code for the event list by sending a Http request.
        /// </summary>
        /// <returns>
        /// A response containing status code and content. Returns the Json string as the content on success, otherwise the content is null.
        /// </returns>
        public static async Task<Response<string>> TryGetEventsJsonAsync(/*string currentDataVersion*/)
        {
            return await GetResponseAsync(/*currentDataVersion*/);
        }

        #endregion
    }
}
