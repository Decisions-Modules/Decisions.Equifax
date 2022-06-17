using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Decisions.Equifax.ConsumerCreditReport.Response;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Equifax.PrequalificationOfOne.Response
{
    public class PrequalificationOfOneResponse : ConsumerCreditReportResponse
    {
        /*Since the responses are the same, extending the Response class of Consumer Credit Report Response*/
        [DataContract]
        [Writable]
        public partial class AddressElement: ConsumerCreditReport.Response.AddressElement
        {
            [JsonProperty("sourceOfAddress")]
            [AllowNull]
            public new FraudVictimIndicator[] SourceOfAddress { get; set; }
            
        }
    }
}