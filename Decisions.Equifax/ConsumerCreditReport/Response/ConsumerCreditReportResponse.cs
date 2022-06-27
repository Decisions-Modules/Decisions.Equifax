using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Equifax.ConsumerCreditReport.Response
{

    [DataContract]
    [Writable]
    public class ConsumerCreditReportResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("consumers")]
        public Consumers Consumers { get; set; }
    }

    [DataContract]
    [Writable]
    public class Consumers
    {
        [JsonProperty("equifaxLimitedConsumerReport")]
        public EquifaxUsConsumerCreditReport[] EquifaxUsConsumerCreditReport { get; set; }
    }

    [DataContract]
    [Writable]
    public class EquifaxUsConsumerCreditReport 
    {
        [JsonProperty("identifier")] public string Identifier { get; set; }

            [JsonProperty("customerReferenceNumber")]
            public string CustomerReferenceNumber { get; set; }

            [JsonProperty("customerNumber")] public string CustomerNumber { get; set; }

            [JsonProperty("consumerReferralCode")] public long ConsumerReferralCode { get; set; }

            [JsonProperty("multipleReportIndicator")]
            public string MultipleReportIndicator { get; set; }

            [JsonProperty("ECOAInquiryType")] public string EcoaInquiryType { get; set; }

            [JsonProperty("hitCode")] public CodeAndDescription HitCode { get; set; }

            [JsonProperty("fileSinceDate")] public string FileSinceDate { get; set; }

            [JsonProperty("lastActivityDate")] public string LastActivityDate { get; set; }

            [JsonProperty("reportDate")] public string ReportDate { get; set; }

            [JsonProperty("subjectName")] public SubjectName SubjectName { get; set; }

            [JsonProperty("subjectSocialNum")] public long SubjectSocialNum { get; set; }

            [JsonProperty("birthDate")] public string BirthDate { get; set; }

            [JsonProperty("nameMatchFlags")] public NameMatchFlags NameMatchFlags { get; set; }

            [JsonProperty("doNotCombineIndicator")]
            public string DoNotCombineIndicator { get; set; }

            [JsonProperty("addressDiscrepancyIndicator")]
            public string AddressDiscrepancyIndicator { get; set; }

            [JsonProperty("fraudIDScanAlertCodes")]
            public CodeAndDescription[] FraudIdScanAlertCodes { get; set; }

            [JsonProperty("fraudVictimIndicator")] public CodeAndDescription FraudVictimIndicator { get; set; }

            [JsonProperty("addresses")] public AddressElement[] Addresses { get; set; }

            [JsonProperty("formerNames")] public FormerName[] FormerNames { get; set; }

            [JsonProperty("employments")] public Employment[] Employments { get; set; }

            [JsonProperty("bankruptcies")] public Bankruptcy[] Bankruptcies { get; set; }

            [JsonProperty("collections")] public Collection[] Collections { get; set; }

            [JsonProperty("alertContacts")] public AlertContact[] AlertContacts { get; set; }

            [JsonProperty("trades")] public Trade[] Trades { get; set; }

            [JsonProperty("inquiries")] public Inquiry[] Inquiries { get; set; }

            [JsonProperty("models")] public Model[] Models { get; set; }

            [JsonProperty("identification")] public Identification Identification { get; set; }

            [JsonProperty("attributes")] public EquifaxUsConsumerCreditReportAttribute[] Attributes { get; set; }

            [JsonProperty("onlineGeoCode")] public OnlineGeoCode[] OnlineGeoCode { get; set; }

            [JsonProperty("OFACAlerts")] public OfacAlert[] OfacAlerts { get; set; }

            [JsonProperty("consumerReferralLocation")]
            public ConsumerReferralLocation ConsumerReferralLocation { get; set; }

            [JsonProperty("alternateDataSources")] public AlternateDataSources AlternateDataSources { get; set; }
    }

    [DataContract]
    [Writable]
    public class AddressElement : EquifaxRequest.AddressElement
    {
    }

    [DataContract]
    [Writable]
    public partial class CodeAndDescription : EquifaxRequest.CodeAndDescription
    {
    }

    [DataContract]
    [Writable]
    public class AlertContact : EquifaxRequest.AlertContact
    {
    }

    [DataContract]
    [Writable]
    public abstract class TelephoneNumberElement : EquifaxRequest.TelephoneNumberElement
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
    public class EquifaxUsConsumerCreditReportAttribute : EquifaxRequest.EquifaxUsConsumerCreditReportAttribute
    {
    }

    [DataContract]
    [Writable]
    public class AttributeAttribute : EquifaxRequest.AttributeAttribute
    {
    }

    [DataContract]
    [Writable]
    public class Bankruptcy
    {
        [JsonProperty("customerNumber")] 
        public string CustomerNumber { get; set; }

        [JsonProperty("type")] 
        public string Type { get; set; }

        [JsonProperty("filer")] 
        public string Filer { get; set; }

        [JsonProperty("industryCode")] 
        public string IndustryCode { get; set; }

        [JsonProperty("currentIntentOrDispositionCode")]
        public CodeAndDescription CurrentIntentOrDispositionCode { get; set; }

        [JsonProperty("dispositionDate")] 
        public string DispositionDate { get; set; }

        [JsonProperty("dateFiled")] 
        public string DateFiled { get; set; }

        [JsonProperty("currentDispositionDate")]
        public string CurrentDispositionDate { get; set; }

        [JsonProperty("dateReported")] 
        public string DateReported { get; set; }
    }

    [DataContract]
    [Writable]
    public class Collection : EquifaxRequest.Collection
    {
    }

    [DataContract]
    [Writable]
    public class ConsumerReferralLocation : EquifaxRequest.ConsumerReferralLocation
    {
    }

    [DataContract]
    [Writable]
    public class ConsumerReferralLocationAddress : EquifaxRequest.ConsumerReferralLocationAddress
    {
    }

    [DataContract]
    [Writable]
    public class ConsumerReferralLocationTelephoneNumber : EquifaxRequest.ConsumerReferralLocationTelephoneNumber
    {
    }

    [DataContract]
    [Writable]
    public class Employment : EquifaxRequest.Employment
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
    public class Inquiry : EquifaxRequest.Inquiry
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
    public class OfacAlert : EquifaxRequest.OfacAlert
    {
    }

    [DataContract]
    [Writable]
    public class OnlineGeoCode : EquifaxRequest.OnlineGeoCode
    {
    }

    [DataContract]
    [Writable]
    public class SubjectName : EquifaxRequest.SubjectName
    {
    }

   [DataContract]
    [Writable]
    public partial class Trade
    {
        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("automatedUpdateIndicator")]
        public string AutomatedUpdateIndicator { get; set; }

        [JsonProperty("monthsReviewed")]
        public string MonthsReviewed { get; set; }

        [JsonProperty("accountDesignator")]
        public CodeAndDescription AccountDesignator { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("dateReported")]
        public string DateReported { get; set; }

        [JsonProperty("dateOpened")]
        public string DateOpened { get; set; }

        [JsonProperty("highCredit")]
        public long? HighCredit { get; set; }

        [JsonProperty("balance")]
        public long? Balance { get; set; }

        [JsonProperty("pastDueAmount")]
        public long? PastDueAmount { get; set; }

        [JsonProperty("portfolioTypeCode")]
        public CodeAndDescription PortfolioTypeCode { get; set; }

        [JsonProperty("rate")]
        public Rate Rate { get; set; }

        [JsonProperty("narrativeCodes")]
        public CodeAndDescription[] NarrativeCodes { get; set; }

        [JsonProperty("rawNarrativeCodes")]
        public string[] RawNarrativeCodes { get; set; }

        [JsonProperty("accountTypeCode")]
        public CodeAndDescription AccountTypeCode { get; set; }

        [JsonProperty("lastPaymentDate")]
        public string LastPaymentDate { get; set; }

        [JsonProperty("scheduledPaymentAmount")]
        public long? ScheduledPaymentAmount { get; set; }

        [JsonProperty("termsDurationCode")]
        public CodeAndDescription TermsDurationCode { get; set; }

        [JsonProperty("termsFrequencyCode")]
        public CodeAndDescription TermsFrequencyCode { get; set; }

        [JsonProperty("paymentHistory1to24")]
        public CodeAndDescription[] PaymentHistory1To24 { get; set; }

        [JsonProperty("thirtyDayCounter")]
        public long? ThirtyDayCounter { get; set; }

        [JsonProperty("sixtyDayCounter")]
        public long? SixtyDayCounter { get; set; }

        [JsonProperty("ninetyDayCounter")]
        public long? NinetyDayCounter { get; set; }

        [JsonProperty("previousHighRate1")]
        public long? PreviousHighRate1 { get; set; }

        [JsonProperty("previousHighDate1")]
        public string PreviousHighDate1 { get; set; }

        [JsonProperty("previousHighRate2")]
        public long? PreviousHighRate2 { get; set; }

        [JsonProperty("previousHighDate2")]
        public string PreviousHighDate2 { get; set; }

        [JsonProperty("previousHighRate3")]
        public long? PreviousHighRate3 { get; set; }

        [JsonProperty("previousHighDate3")]
        public string PreviousHighDate3 { get; set; }

        [JsonProperty("24MonthPaymentHistory", NullValueHandling = NullValueHandling.Ignore)]
        public CodeAndDescription[] The24MonthPaymentHistory { get; set; }

        [JsonProperty("dateMajorDelinquencyFirstReported")]
        public string DateMajorDelinquencyFirstReported { get; set; }

        [JsonProperty("originalChargeOffAmount")]
        public long? OriginalChargeOffAmount { get; set; }

        [JsonProperty("previousHighRatePaymentHistory")]
        public long? PreviousHighRatePaymentHistory { get; set; }

        [JsonProperty("previousHighDatePaymentHistory")]
        public string PreviousHighDatePaymentHistory { get; set; }

        [JsonProperty("closedDate")]
        public string ClosedDate { get; set; }

        [JsonProperty("activityDesignatorCode")]
        public CodeAndDescription ActivityDesignatorCode { get; set; }

        [JsonProperty("purchasedFromOrSoldCreditorIndicator")]
        public CodeAndDescription PurchasedFromOrSoldCreditorIndicator { get; set; }

        [JsonProperty("purchasedFromOrSoldCreditorName")]
        public string PurchasedFromOrSoldCreditorName { get; set; }

        [JsonProperty("creditorClassificationCode")]
        public CodeAndDescription CreditorClassificationCode { get; set; }

        [JsonProperty("actualPaymentAmount")]
        public long? ActualPaymentAmount { get; set; }
    }

    [DataContract]
    [Writable]
    public class Rate
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
