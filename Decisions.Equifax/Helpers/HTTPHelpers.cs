using System;
using System.IO;
using System.Net;
using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using DecisionsFramework;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;
using System.Web;
using DecisionsFramework.Utilities.Data;

namespace Decisions.Equifax.Helpers
{
    public static class HTTPHelpers
    {
        private static readonly Log log = new Log(EquifaxConstants.LogCat);

        
        
        /// <summary>
        /// Helper: Execute API Endpoint
        /// </summary>
        public static ConsumerCreditReportResponse ExecuteCreditReportRequest(ConsumerCreditReportRequest request)
        {
            // Configuration
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            
            string scope = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxConsumerCreditReportScope;
            if (string.IsNullOrWhiteSpace(scope))
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            
            
            // Build request
            string requestToken = GetOAuthToken(scope);
            string requestString = JsonConvert.SerializeObject(request, jsonSettings);
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxConsumerCreditReportEndpoint;
            var req = (System.Net.HttpWebRequest) System.Net.WebRequest.Create(requestUrl);
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

                ConsumerCreditReportResponse cr = JsonConvert.DeserializeObject<ConsumerCreditReportResponse>(
                    responseString, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                return cr;
            }
            catch (WebException ex)
            {
                log.Error(ex.Message);
            }

            return null;
        }
        
        
        
        /// <summary>
        /// Helper: Generic Get OAuth via client credentials
        /// </summary>
        private static string GetOAuthToken(string scope)
        {
            // Configuration
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxOAuthUrl;
            string clientId = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxClientId;
            string clientSecret = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxClientSecret;

            if (string.IsNullOrWhiteSpace(requestUrl) || string.IsNullOrWhiteSpace(clientId) ||
                string.IsNullOrWhiteSpace(clientSecret))
            {
                log.Error(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            
            
            // Build request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUrl);
            string body = "scope=" + Uri.EscapeUriString(scope) + "&grant_type=client_credentials";
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes($"{clientId}:{clientSecret}"));
            request.Method = "POST";
            request.ContentLength = body.Length;
            request.Headers.Add("Authorization", "Basic " + encoded);
            request.ContentType = "application/x-www-form-urlencoded";

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