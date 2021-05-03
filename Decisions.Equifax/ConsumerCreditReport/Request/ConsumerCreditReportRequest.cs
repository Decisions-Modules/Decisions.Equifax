using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Equifax.ConsumerCreditReport.Request
{
    [DataContract]
    [Writable]
    public partial class ConsumerCreditReportRequest
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("consumers")]
        public Consumers Consumers { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("customerReferenceIdentifier")]
        public string CustomerReferenceIdentifier { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("customerConfiguration")]
        public CustomerConfiguration CustomerConfiguration { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Consumers
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("name")]
        public Name[] Name { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("socialNum")]
        public PhoneNumber[] SocialNum { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("addresses")]
        public Address[] Addresses { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("phoneNumbers")]
        public PhoneNumber[] PhoneNumbers { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("employments")]
        public Employments Employments { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Address
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("houseNumber")]
        public long HouseNumber { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("streetType")]
        public string StreetType { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("apartmentNumber")]
        public long ApartmentNumber { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("city")]
        public string City { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("state")]
        public string State { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("zip")]
        public string Zip { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Employments
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("employerName")]
        public string EmployerName { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Name
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class PhoneNumber
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("number")]
        public string Number { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class CustomerConfiguration
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("equifaxUSConsumerCreditReport")]
        public EquifaxUsConsumerCreditReport EquifaxUsConsumerCreditReport { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class EquifaxUsConsumerCreditReport
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("memberNumber")]
        public string MemberNumber { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("securityCode")]
        public string SecurityCode { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("codeDescriptionRequired")]
        public bool CodeDescriptionRequired { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("models")]
        public Model[] Models { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("endUserInformation")]
        public EndUserInformation EndUserInformation { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("customerCode")]
        public string CustomerCode { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("multipleReportIndicator")]
        public string MultipleReportIndicator { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("ECOAInquiryType")]
        public string EcoaInquiryType { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("optionalFeatureCode")]
        public string[] OptionalFeatureCode { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("vendorIdentificationCode")]
        public string VendorIdentificationCode { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class EndUserInformation
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("endUsersName")]
        public string EndUsersName { get; set; }

        [DataMember]
        [WritableValue]
        [JsonProperty("permissiblePurposeCode")]
        public string PermissiblePurposeCode { get; set; }
    }

    [DataContract]
    [Writable]
    public partial class Model
    {
        [DataMember]
        [WritableValue]
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
    
}