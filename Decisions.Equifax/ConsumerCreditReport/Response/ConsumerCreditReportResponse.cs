﻿using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Equifax.ConsumerCreditReport.Response
{

    [DataContract]
    [Writable]
    public partial class ConsumerCreditReportResponse
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
        public EquifaxUsConsumerCreditReport[] EquifaxUsConsumerCreditReport { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class EquifaxUsConsumerCreditReport
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("customerReferenceNumber")]
        public string CustomerReferenceNumber { get; set; }

        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("consumerReferralCode")]
        public long ConsumerReferralCode { get; set; }

        [JsonProperty("multipleReportIndicator")]
        public string MultipleReportIndicator { get; set; }

        [JsonProperty("ECOAInquiryType")]
        public string EcoaInquiryType { get; set; }

        [JsonProperty("hitCode")]
        public FraudVictimIndicator HitCode { get; set; }

        [JsonProperty("fileSinceDate")]
        public string FileSinceDate { get; set; }

        [JsonProperty("lastActivityDate")]
        public string LastActivityDate { get; set; }

        [JsonProperty("reportDate")]
        public string ReportDate { get; set; }

        [JsonProperty("subjectName")]
        public SubjectName SubjectName { get; set; }

        [JsonProperty("subjectSocialNum")]
        public long SubjectSocialNum { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("nameMatchFlags")]
        public NameMatchFlags NameMatchFlags { get; set; }

        [JsonProperty("doNotCombineIndicator")]
        public string DoNotCombineIndicator { get; set; }

        [JsonProperty("addressDiscrepancyIndicator")]
        public string AddressDiscrepancyIndicator { get; set; }

        [JsonProperty("fraudIDScanAlertCodes")]
        public FraudVictimIndicator[] FraudIdScanAlertCodes { get; set; }

        [JsonProperty("fraudVictimIndicator")]
        public FraudVictimIndicator FraudVictimIndicator { get; set; }

        [JsonProperty("addresses")]
        public AddressElement[] Addresses { get; set; }

        [JsonProperty("formerNames")]
        public FormerName[] FormerNames { get; set; }

        [JsonProperty("employments")]
        public Employment[] Employments { get; set; }

        [JsonProperty("bankruptcies")]
        public Bankruptcy[] Bankruptcies { get; set; }

        [JsonProperty("collections")]
        public Collection[] Collections { get; set; }

        [JsonProperty("alertContacts")]
        public AlertContact[] AlertContacts { get; set; }

        [JsonProperty("trades")]
        public Trade[] Trades { get; set; }

        [JsonProperty("inquiries")]
        public Inquiry[] Inquiries { get; set; }

        [JsonProperty("models")]
        public Model[] Models { get; set; }

        [JsonProperty("identification")]
        public Identification Identification { get; set; }

        [JsonProperty("attributes")]
        public EquifaxUsConsumerCreditReportAttribute[] Attributes { get; set; }

        [JsonProperty("onlineGeoCode")]
        public OnlineGeoCode[] OnlineGeoCode { get; set; }

        [JsonProperty("OFACAlerts")]
        public OfacAlert[] OfacAlerts { get; set; }

        [JsonProperty("consumerReferralLocation")]
        public ConsumerReferralLocation ConsumerReferralLocation { get; set; }

        [JsonProperty("alternateDataSources")]
        public AlternateDataSources AlternateDataSources { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class AddressElement
    {
        [JsonProperty("addressType")]
        public string AddressType { get; set; }

        [JsonProperty("houseNumber")]
        public long HouseNumber { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("streetType")]
        public string StreetType { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("stateAbbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("sourceOfAddress")]
        public FraudVictimIndicator SourceOfAddress { get; set; }

        [JsonProperty("dateFirstReported")]
        public string DateFirstReported { get; set; }

        [JsonProperty("dateLastReported")]
        public string DateLastReported { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class FraudVictimIndicator
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class AlertContact
    {
        [JsonProperty("alertType")]
        public FraudVictimIndicator AlertType { get; set; }

        [JsonProperty("dateReported")]
        public string DateReported { get; set; }

        [JsonProperty("effectiveDate")]
        public string EffectiveDate { get; set; }

        [JsonProperty("telephoneNumbers")]
        public TelephoneNumberElement[] TelephoneNumbers { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class TelephoneNumberElement
    {
        [JsonProperty("telephoneNumberType")]
        public FraudVictimIndicator TelephoneNumberType { get; set; }

        [JsonProperty("telephoneNumber")]
        public string TelephoneNumber { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class AlternateDataSources
    {
        [JsonProperty("militaryLendingCoveredBorrower")]
        public MilitaryLendingCoveredBorrower MilitaryLendingCoveredBorrower { get; set; }

        [JsonProperty("fraudIQSyntheticIDV2Alerts")]
        public FraudIqSyntheticIdv2Alerts FraudIqSyntheticIdv2Alerts { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class FraudIqSyntheticIdv2Alerts
    {
        [JsonProperty("nonRegulatedIdentifier")]
        public string NonRegulatedIdentifier { get; set; }

        [JsonProperty("hitNohitIndicator")]
        public long HitNohitIndicator { get; set; }

        [JsonProperty("syntheticIdVer2")]
        public string SyntheticIdVer2 { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class MilitaryLendingCoveredBorrower
    {
        [JsonProperty("regulatedIdentifier")]
        public string RegulatedIdentifier { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("coveredBorrowerStatus")]
        public string CoveredBorrowerStatus { get; set; }

        [JsonProperty("referralContactNumber")]
        public string ReferralContactNumber { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class EquifaxUsConsumerCreditReportAttribute
    {
        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("attributes")]
        public AttributeAttribute[] Attributes { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class AttributeAttribute
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Bankruptcy
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
        public FraudVictimIndicator CurrentIntentOrDispositionCode { get; set; }

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
    public partial class Collection
    {
        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("clientNameOrNumber")]
        public string ClientNameOrNumber { get; set; }

        [JsonProperty("statusCode")]
        public FraudVictimIndicator StatusCode { get; set; }

        [JsonProperty("narrativeCodes")]
        public FraudVictimIndicator[] NarrativeCodes { get; set; }

        [JsonProperty("rawNarrativeCodes")]
        public string[] RawNarrativeCodes { get; set; }

        [JsonProperty("indicator")]
        public string Indicator { get; set; }

        [JsonProperty("dateReported")]
        public string DateReported { get; set; }

        [JsonProperty("dateAssigned")]
        public string DateAssigned { get; set; }

        [JsonProperty("originalAmount")]
        public long OriginalAmount { get; set; }

        [JsonProperty("statusDate")]
        public string StatusDate { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("dateOfFirstDelinquency")]
        public string DateOfFirstDelinquency { get; set; }

        [JsonProperty("accountDesignatorCode")]
        public FraudVictimIndicator AccountDesignatorCode { get; set; }

        [JsonProperty("creditorClassificationCode")]
        public FraudVictimIndicator CreditorClassificationCode { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class ConsumerReferralLocation
    {
        [JsonProperty("bureauCode")]
        public long BureauCode { get; set; }

        [JsonProperty("bureauName")]
        public string BureauName { get; set; }

        [JsonProperty("address")]
        public ConsumerReferralLocationAddress Address { get; set; }

        [JsonProperty("telephoneNumber")]
        public ConsumerReferralLocationTelephoneNumber TelephoneNumber { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class ConsumerReferralLocationAddress
    {
        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("stateAbbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class ConsumerReferralLocationTelephoneNumber
    {
        [JsonProperty("telephoneNumber")]
        public string TelephoneNumber { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Employment
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("employer")]
        public string Employer { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class FormerName
    {
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Identification
    {
        [JsonProperty("subjectSocialNum")]
        public long SubjectSocialNum { get; set; }

        [JsonProperty("socialNumConfirmed")]
        public string SocialNumConfirmed { get; set; }

        [JsonProperty("socialMatchFlags")]
        public string SocialMatchFlags { get; set; }

        [JsonProperty("inquirySocialNum")]
        public long InquirySocialNum { get; set; }

        [JsonProperty("inquirySocialNumStateIssued")]
        public string InquirySocialNumStateIssued { get; set; }

        [JsonProperty("inquirySocialNumYearIssued")]
        public long InquirySocialNumYearIssued { get; set; }

        [JsonProperty("socialNumMatch")]
        public string SocialNumMatch { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Inquiry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("industryCode")]
        public string IndustryCode { get; set; }

        [JsonProperty("inquiryDate")]
        public string InquiryDate { get; set; }

        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Model
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("FICOScoreIndicatorCode")]
        public FraudVictimIndicator FicoScoreIndicatorCode { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("reasons")]
        public ScoreNumberOrMarketMaxIndustryCode[] Reasons { get; set; }

        [JsonProperty("inquiryKeyFactor")]
        public FraudVictimIndicator InquiryKeyFactor { get; set; }

        [JsonProperty("riskBasedPricingOrModel")]
        public RiskBasedPricingOrModel RiskBasedPricingOrModel { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("modelIDOrScorecard")]
        public long? ModelIdOrScorecard { get; set; }

        [JsonProperty("scoreNumberOrMarketMaxIndustryCode")]
        public ScoreNumberOrMarketMaxIndustryCode ScoreNumberOrMarketMaxIndustryCode { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class ScoreNumberOrMarketMaxIndustryCode
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class RiskBasedPricingOrModel
    {
        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("lowRange")]
        public long LowRange { get; set; }

        [JsonProperty("highRange")]
        public long HighRange { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class NameMatchFlags
    {
        [JsonProperty("firstNameMatchFlag")]
        public string FirstNameMatchFlag { get; set; }

        [JsonProperty("lastNameMatchFlag")]
        public string LastNameMatchFlag { get; set; }

        [JsonProperty("middleNameMatchFlag")]
        public string MiddleNameMatchFlag { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class OfacAlert
    {
        [JsonProperty("revisedLegalVerbiageIndicator")]
        public long RevisedLegalVerbiageIndicator { get; set; }

        [JsonProperty("memberFirmCode")]
        public string MemberFirmCode { get; set; }

        [JsonProperty("cdcTransactionDate")]
        public string CdcTransactionDate { get; set; }

        [JsonProperty("cdcTransactionTime")]
        public long CdcTransactionTime { get; set; }

        [JsonProperty("transactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("cdcResponseCode")]
        public string CdcResponseCode { get; set; }

        [JsonProperty("legalVerbiage")]
        public string LegalVerbiage { get; set; }

        [JsonProperty("dataSegmentRegulated")]
        public string DataSegmentRegulated { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class OnlineGeoCode
    {
        [JsonProperty("streetNumber")]
        public long StreetNumber { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("streetTypeOrDirection")]
        public string StreetTypeOrDirection { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateAbbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("typeOfAddress")]
        public FraudVictimIndicator TypeOfAddress { get; set; }

        [JsonProperty("returnCode1")]
        public FraudVictimIndicator ReturnCode1 { get; set; }

        [JsonProperty("returnCode2")]
        public FraudVictimIndicator ReturnCode2 { get; set; }

        [JsonProperty("returnCode3")]
        public FraudVictimIndicator ReturnCode3 { get; set; }

        [JsonProperty("returnCode4")]
        public FraudVictimIndicator ReturnCode4 { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class SubjectName
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
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
        public FraudVictimIndicator AccountDesignator { get; set; }

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
        public FraudVictimIndicator PortfolioTypeCode { get; set; }

        [JsonProperty("rate")]
        public Rate Rate { get; set; }

        [JsonProperty("narrativeCodes")]
        public FraudVictimIndicator[] NarrativeCodes { get; set; }

        [JsonProperty("rawNarrativeCodes")]
        public string[] RawNarrativeCodes { get; set; }

        [JsonProperty("accountTypeCode")]
        public FraudVictimIndicator AccountTypeCode { get; set; }

        [JsonProperty("lastPaymentDate")]
        public string LastPaymentDate { get; set; }

        [JsonProperty("scheduledPaymentAmount")]
        public long? ScheduledPaymentAmount { get; set; }

        [JsonProperty("termsDurationCode")]
        public FraudVictimIndicator TermsDurationCode { get; set; }

        [JsonProperty("termsFrequencyCode")]
        public FraudVictimIndicator TermsFrequencyCode { get; set; }

        [JsonProperty("paymentHistory1to24")]
        public FraudVictimIndicator[] PaymentHistory1To24 { get; set; }

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
        public FraudVictimIndicator[] The24MonthPaymentHistory { get; set; }

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
        public FraudVictimIndicator ActivityDesignatorCode { get; set; }

        [JsonProperty("purchasedFromOrSoldCreditorIndicator")]
        public FraudVictimIndicator PurchasedFromOrSoldCreditorIndicator { get; set; }

        [JsonProperty("purchasedFromOrSoldCreditorName")]
        public string PurchasedFromOrSoldCreditorName { get; set; }

        [JsonProperty("creditorClassificationCode")]
        public FraudVictimIndicator CreditorClassificationCode { get; set; }

        [JsonProperty("actualPaymentAmount")]
        public long? ActualPaymentAmount { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Rate
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
    
}