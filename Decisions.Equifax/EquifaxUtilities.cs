using System.IO;
using System.Net;
using System.Net.Http;
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
        
        private static JsonSerializerSettings jsonSerializerSettings => new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static ConsumerCreditReportResponse ExecuteCreditReportRequest(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string responseString = RequestSerializer(request, scope, requestUrl);

            ConsumerCreditReportResponse limitedCreditResponse = JsonConvert.DeserializeObject<ConsumerCreditReportResponse>(
                    responseString, jsonSerializerSettings);
                return limitedCreditResponse;
        }
        
        internal static PreQualificationOfOneResponse ExecutePreQualificationRequest(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string responseString = RequestSerializer(request, scope, requestUrl);
            PreQualificationOfOneResponse preQualResponse  = JsonConvert.DeserializeObject<PreQualificationOfOneResponse>(
                responseString, jsonSerializerSettings);
            
            return preQualResponse;
        }

        private static string  RequestSerializer(ConsumerCreditReportRequest request, string scope, string requestUrl)
        {
            string requestToken = GetOAuthToken(scope);
            string requestString = JsonConvert.SerializeObject(request, jsonSerializerSettings);
            var req = (HttpWebRequest) WebRequest.Create(requestUrl);
            req.Headers.Add("Authorization: Bearer " + requestToken);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = requestString.Length;
            req.AutomaticDecompression = DecompressionMethods.GZip;

            HttpClient client = new HttpClient();
            
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
                        using StreamReader streamReader = new StreamReader(dataStream);
                        responseString = streamReader.ReadToEnd();
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
            EquifaxSettings equifaxSettings = ModuleSettingsAccessor<EquifaxSettings>.GetSettings();
      
            if (string.IsNullOrWhiteSpace(equifaxSettings.EquifaxOAuthUrl) || string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientId) ||
                string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientSecret))
            {
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(equifaxSettings.EquifaxOAuthUrl);
            string body = "scope=" + System.Web.HttpUtility.UrlEncode( scope ) + "&grant_type=client_credentials";
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes($"{equifaxSettings.EquifaxClientId}:{equifaxSettings.EquifaxClientSecret}"));
            request.Method = "POST";
            request.ContentLength = body.Length;
            request.Headers.Add("Authorization", "Basic " + encoded);
            request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            log.Debug($"URL:{equifaxSettings.EquifaxOAuthUrl}\r\nHasClientId:{(!string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientId))}\r\nHasClientSecret:{(!string.IsNullOrWhiteSpace(equifaxSettings.EquifaxClientSecret))}\r\nHasAuthorization:{(!string.IsNullOrWhiteSpace(encoded))}");

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
                throw new LoggedException(EquifaxConstants.CANNOT_GET_OAUTH_TOKEN);
            }
            return resp.AccessToken;
        }
    }
}