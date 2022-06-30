using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using Decisions.Equifax.PreQualificationOfOne.Response;
using DecisionsFramework;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.Equifax
{
    public static class EquifaxUtilities
    {
        private static readonly Log log = new Log(EquifaxConstants.LogCat);

        private static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static ConsumerCreditReportResponse ExecuteCreditReportRequest(ConsumerCreditReportRequest request,
            string scope, string requestUrl)
        {
            string responseString = RequestSerializer(request, scope, requestUrl);

            ConsumerCreditReportResponse limitedCreditResponse =
                JsonConvert.DeserializeObject<ConsumerCreditReportResponse>(
                    responseString, JsonSerializerSettings);
            return limitedCreditResponse;
        }

        internal static PreQualificationOfOneResponse ExecutePreQualificationRequest(
            ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string responseString = RequestSerializer(request, scope, requestUrl);
            PreQualificationOfOneResponse preQualificationResponse =
                JsonConvert.DeserializeObject<PreQualificationOfOneResponse>(
                    responseString, JsonSerializerSettings);

            return preQualificationResponse;
        }


        private static string RequestSerializer(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string requestToken = GetOAuthToken(scope);
            string requestString = JsonConvert.SerializeObject(request, JsonSerializerSettings);
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            HttpClient client = new HttpClient(handler);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestString);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", requestToken);
            HttpResponseMessage responseMessage = client.PostAsync(requestUrl, requestMessage.Content).GetAwaiter().GetResult();
           
            responseMessage.EnsureSuccessStatusCode();
            
            log.Debug($"URL:{requestUrl}\r\nScope:{scope}\r\nHasToken:{(!string.IsNullOrWhiteSpace(requestToken))}");
            string responseString;
            using (Stream responseStream = responseMessage.Content.ReadAsStream())
            {
                // Get response
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    responseString = streamReader.ReadToEnd();
                }
            }

            return responseString;
        }



        /// <summary>
        /// Helper: Generic Get OAuth via client credentials
        /// </summary>
        private static string GetOAuthToken(string scope)
        {
            EquifaxSettings equifaxSettings = ModuleSettingsAccessor<EquifaxSettings>.GetSettings();
      
            if (string.IsNullOrWhiteSpace(equifaxSettings.EquifaxOAuthUrl) || string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientId) ||
                string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientSecret))
            {
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{equifaxSettings.EquifaxClientId}:{equifaxSettings.EquifaxClientSecret}"));
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, equifaxSettings.EquifaxOAuthUrl);
            List<KeyValuePair<string, string>>  values = new List<KeyValuePair<string, string>> {new("grant_type", "client_credentials"), new ("scope", scope)};
            FormUrlEncodedContent credsEncodedContent = new FormUrlEncodedContent(values);
            requestMessage.Content = credsEncodedContent;
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded); 
            
            HttpResponseMessage responseMessage = client.PostAsync(equifaxSettings.EquifaxOAuthUrl, requestMessage.Content).GetAwaiter().GetResult();
            
            responseMessage.EnsureSuccessStatusCode();
            log.Debug($"URL:{equifaxSettings.EquifaxOAuthUrl}\r\nHasClientId:{(!string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientId))}\r\nHasClientSecret:{(!string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientSecret))}\r\nHasAuthorization:{(!string.IsNullOrWhiteSpace(encoded))}");
        
            string responseString;
            using (Stream responseStream = responseMessage.Content.ReadAsStream())
            {
                // Get response
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    responseString = streamReader.ReadToEnd();
                }
            }

            OAuthResponse resp = JsonConvert.DeserializeObject<OAuthResponse>(responseString);

            if (resp == null)
            {
                throw new LoggedException(EquifaxConstants.CANNOT_GET_OAUTH_TOKEN);
            }
            return resp.AccessToken;
        }
    }
}