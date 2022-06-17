using System;
using System.IO;
using System.Net;
using System.Text.Encodings.Web;
using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using Decisions.Equifax.PrequalificationOfOne.Response;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.CoreSteps;
using DecisionsFramework.Design.Flow.Mapping;
using DecisionsFramework.Design.Properties.Attributes;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Services.ContextData;
using Newtonsoft.Json;
namespace Decisions.Equifax
{
    public class EquifaxUtilities
    {
        private static readonly Log log = new Log(EquifaxConstants.LogCat);
        
        internal static ConsumerCreditReportResponse ExecuteCreditReportRequest(ConsumerCreditReportRequest request, string scope, string requestUrl, string stepCalled )
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            
            if (string.IsNullOrWhiteSpace(scope))
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            string requestToken = GetOAuthToken(scope);
            string requestString = JsonConvert.SerializeObject(request, jsonSettings);
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

                ConsumerCreditReportResponse cr = new ConsumerCreditReportResponse();
                if (stepCalled == "LimitedCreditReport")
                {
                    cr = JsonConvert.DeserializeObject<ConsumerCreditReportResponse>(
                        responseString, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                }

                if (stepCalled == "Prequalification")
                {
                    cr = JsonConvert.DeserializeObject<PrequalificationOfOneResponse>(
                        responseString, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                }

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
