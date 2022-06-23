using System.IO;
using System.Net;
using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using Decisions.Equifax.PreQualificationOfOne.Response;
using DecisionsFramework;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Decisions.Equifax
{
    public class EquifaxUtilities
    {
        public static readonly Log log = new Log(EquifaxConstants.LogCat);
        
        public static JsonSerializerSettings js => new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static ConsumerCreditReportResponse ExecuteCreditReportRequest(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string responseString = RequestSerializer(request, scope, requestUrl);

            ConsumerCreditReportResponse limitedCreditResponse;
           
                limitedCreditResponse = JsonConvert.DeserializeObject<ConsumerCreditReportResponse>(
                    responseString, js);
                return limitedCreditResponse;
        }
        internal static PreQualificationOfOneResponse ExecutePrequalificationRequest(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string responseString = RequestSerializer(request, scope, requestUrl);
            PreQualificationOfOneResponse preQualResponse;
            preQualResponse  = JsonConvert.DeserializeObject<PreQualificationOfOneResponse>(
                responseString, js);
            
            return preQualResponse;
        }

        private static string  RequestSerializer(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            JsonSerializerSettings jsonSettings = js;
            
            string requestToken = GetOAuthToken(scope);
            string requestString = JsonConvert.SerializeObject(request, jsonSettings);
            var req = (HttpWebRequest) WebRequest.Create(requestUrl);
            req.Headers.Add("Authorization: Bearer " + requestToken);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = requestString.Length;
            req.AutomaticDecompression = DecompressionMethods.GZip;

            
            log.Debug($"URL:{requestUrl}\r\nScope:{scope}\r\nHasToken:{(!string.IsNullOrWhiteSpace(requestToken))}");

            // Write body
            using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
            {
                sw.Write(requestString);
                sw.Flush();
            }

            // Get response
            string responseString = string.Empty;
            try
            {
                using (var httpResponse = (HttpWebResponse) req.GetResponse())
                using (Stream dataStream = httpResponse.GetResponseStream())
                {
                    if (dataStream != null)
                    {
                        string sts = httpResponse.ContentEncoding;
                        using (StreamReader streamReader = new StreamReader(dataStream))
                        {
                            responseString = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                log.Error(ex.Message);
            }

            return responseString;
        }
        /// <summary>
        /// Helper: Generic Get OAuth via client credentials
        /// </summary>

         private static string GetOAuthToken(string scope)
        {
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxOAuthUrl;
            string clientId = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxClientId;
            string clientSecret = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxClientSecret;

            if (string.IsNullOrWhiteSpace(requestUrl) || string.IsNullOrWhiteSpace(clientId) ||
                string.IsNullOrWhiteSpace(clientSecret))
            {
                log.Error(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUrl);
            string body = "scope=" + System.Web.HttpUtility.UrlEncode( scope ) + "&grant_type=client_credentials";
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes($"{clientId}:{clientSecret}"));
            request.Method = "POST";
            request.ContentLength = body.Length;
            request.Headers.Add("Authorization", "Basic " + encoded);
            request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            log.Debug($"URL:{requestUrl}\r\nHasClientId:{(!string.IsNullOrWhiteSpace(clientId))}\r\nHasClientSecret:{(!string.IsNullOrWhiteSpace(clientSecret))}\r\nHasAuthorization:{(!string.IsNullOrWhiteSpace(encoded))}");

            // Write body
            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(body);
                sw.Flush();
            }
            
            // Get response
            string responseString = string.Empty;
            try
            {
                using (var httpResponse = (HttpWebResponse) request.GetResponse())
                using (Stream dataStream = httpResponse.GetResponseStream())
                {
                    if (dataStream != null)
                    {
                        string sts = httpResponse.ContentEncoding;
                        using (StreamReader streamReader = new StreamReader(dataStream))
                        {
                            responseString = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                log.Error(ex.Message);
            }

            OAuthResponse resp = JsonConvert.DeserializeObject<OAuthResponse>(responseString);

            if (resp == null)
            {
                log.Error(EquifaxConstants.CANNOT_GET_OAUTH_TOKEN);
            }
            return resp.AccessToken;
        }
    }
}