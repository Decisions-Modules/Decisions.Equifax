using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Equifax.PreQualificationOfOne.Response
{   
        [DataContract]
        [Writable]
        public class PreQualificationOfOneResponse
        {
            [JsonProperty("status")] 
            public string Status { get; set; }

            [JsonProperty("consumers")] 
            public Consumers Consumers { get; set; }
        }

        [DataContract]
        [Writable]
        public partial class Consumers
        {
            [JsonProperty("equifaxUSConsumerCreditReport")]
            public virtual EquifaxUsConsumerCreditReport[] EquifaxUsConsumerCreditReport { get; set; }
        }

        [DataContract]
        [Writable]
        public partial class EquifaxUsConsumerCreditReport : EquifaxRequest.EquifaxUsConsumerCreditReport
        {
        }

        [DataContract]
        [Writable]
        public partial class AddressElement : EquifaxRequest.AddressElement
        {       
        }

        [DataContract]
        [Writable]
        public class CodeAndDescription : EquifaxRequest.CodeAndDescription
        {
        }

        [DataContract]
        [Writable]
        public class AlertContact : EquifaxRequest.AlertContact
        {
        }

        [DataContract]
        [Writable]
        public class TelephoneNumberElement : EquifaxRequest.TelephoneNumberElement
        {
        }

        [DataContract]
        [Writable]
        public class AlternateDataSources : EquifaxRequest.AlternateDataSources
        {
        
        }

        [DataContract]
        [Writable]
        public class FraudIqSyntheticIdv2Alerts : EquifaxRequest.FraudIqSyntheticIdv2Alerts
        {
        }

        [DataContract]
        [Writable]
        public class MilitaryLendingCoveredBorrower : EquifaxRequest.MilitaryLendingCoveredBorrower
        {
        }

        [DataContract]
        [Writable]
        public partial class EquifaxUsConsumerCreditReportAttribute : EquifaxRequest
        {
        }

        [DataContract]
        [Writable]
        public partial class AttributeAttribute : EquifaxRequest.AttributeAttribute
        {
        }

        [DataContract]
        [Writable]
        public partial class Bankruptcy : EquifaxRequest.Bankruptcy
        {
        }

        [DataContract]
        [Writable]
        public partial class Collection : EquifaxRequest.Collection
        {
        }

        [DataContract]
        [Writable]
        public partial class ConsumerReferralLocation : EquifaxRequest.ConsumerReferralLocation
        {
        }

        [DataContract]
        [Writable]
        public partial class ConsumerReferralLocationAddress : EquifaxRequest.ConsumerReferralLocationAddress
        {
        }

        [DataContract]
        [Writable]
        public class ConsumerReferralLocationTelephoneNumber : EquifaxRequest.ConsumerReferralLocationTelephoneNumber
        {
        }

        [DataContract]
        [Writable]
        public partial class Employment : EquifaxRequest.Employment
        {
        }

        [DataContract]
        [Writable]
        public class FormerName : EquifaxRequest.FormerName
        {
        }

        [DataContract]
        [Writable]
        public class Identification : EquifaxRequest.Identification
        {
        }

        [DataContract]
        [Writable]
        public partial class Inquiry : EquifaxRequest.Inquiry
        {
        }

        [DataContract]
        [Writable]
        public class Model : EquifaxRequest.Model
        {
        }

        [DataContract]
        [Writable]
        public class ScoreNumberOrMarketMaxIndustryCode : EquifaxRequest.ScoreNumberOrMarketMaxIndustryCode
        {
        }

        [DataContract]
        [Writable]
        public class RiskBasedPricingOrModel : EquifaxRequest.RiskBasedPricingOrModel
        {
        }

        [DataContract]
        [Writable]
        public class NameMatchFlags : EquifaxRequest.NameMatchFlags
        {
        }

        [DataContract]
        [Writable]
        public partial class OfacAlert : EquifaxRequest.OfacAlert
        {
        }

        [DataContract]
        [Writable]
        public partial class OnlineGeoCode : EquifaxRequest.OnlineGeoCode
        {
           
        }

        [DataContract]
        [Writable]
        public  partial class SubjectName : EquifaxRequest.SubjectName
        {
        }

        [DataContract]
        [Writable]
        public partial class Trade : EquifaxRequest.Trade
        {
        }
    }
