using System.Collections.Generic;
using DecisionsFramework;
using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Actions;
using DecisionsFramework.ServiceLayer.Actions.Common;
using DecisionsFramework.ServiceLayer.Services.Accounts;
using DecisionsFramework.ServiceLayer.Services.Administration;
using DecisionsFramework.ServiceLayer.Services.Folder;
using DecisionsFramework.ServiceLayer.Utilities;

namespace Decisions.Equifax
{
    public class EquifaxSettings : AbstractModuleSettings, IInitializable, IValidationSource
    {
        [ORMField]
        [PropertyClassification(new string[] {"OAuth Settings"} , "OAuth URL", 4)]
        public string EquifaxOAuthUrl { get; set; }

        [ORMField]
        [PropertyClassification(new string[] {"OAuth Settings"} , "API Client ID", 5)]
        public string EquifaxClientId { get; set; }

        [ORMField]
        [PropertyClassification(new string[] {"OAuth Settings"} , "API Client Secret", 6)]
        public string EquifaxClientSecret { get; set; }
        
        [ORMField]
        [PropertyClassification(new string[] {"Pre-qualification of One"} , "API Endpoint Url", 2)]
        public string EquifaxPreQualificationOfOneEndpoint { get; set; }

        [ORMField]
        [PropertyClassification(new string[] {"Pre-qualification of One"}, "OAuth Scope", 3)]
        public string EquifaxPreQualificationOfOneScope { get; set; }
       
        [ORMField]
        [PropertyClassification(new string[] {"Limited Consumer Report"}, "API Endpoint Url", 0)]
        public string EquifaxConsumerCreditReportEndpoint { get; set; }

        [ORMField]
        [PropertyClassification(new string[] {"Limited Consumer Report"}, "OAuth Scope", 1)]
        public string EquifaxConsumerCreditReportScope { get; set; }

        public ValidationIssue[] GetValidationIssues()
        {
            List<ValidationIssue> validationIssues = new List<ValidationIssue>();

            // OAuth URL
            if (string.IsNullOrWhiteSpace(EquifaxOAuthUrl))
                validationIssues.Add(new ValidationIssue(this, "The OAuth URL is required.", null, BreakLevel.Fatal, nameof(EquifaxOAuthUrl)));

            // Client Id
            if (string.IsNullOrWhiteSpace(EquifaxClientId))
                validationIssues.Add(new ValidationIssue(this, "Your Client Id is required.", null, BreakLevel.Fatal, nameof(EquifaxClientId)));

            // Client Secret
            if (string.IsNullOrWhiteSpace(EquifaxClientSecret))
                validationIssues.Add(new ValidationIssue(this, "Your Client Secret is required.", null, BreakLevel.Fatal, nameof(EquifaxClientSecret)));

            // API Endpoint
            if (string.IsNullOrWhiteSpace(EquifaxConsumerCreditReportEndpoint))
                validationIssues.Add(new ValidationIssue(this, "The Consumer Credit Report Endpoint Url is required.", null, BreakLevel.Fatal, nameof(EquifaxConsumerCreditReportEndpoint)));

            // OAuth Scope for Endpoint
            if (string.IsNullOrWhiteSpace(EquifaxConsumerCreditReportScope))
                validationIssues.Add(new ValidationIssue(this, "The OAuth Scope for Consumer Credit Report is required.", null, BreakLevel.Fatal, nameof(EquifaxConsumerCreditReportScope)));

            // API Endpoint
            if (string.IsNullOrWhiteSpace(EquifaxPreQualificationOfOneEndpoint))
                validationIssues.Add(new ValidationIssue(this, "The PreQualification of One Endpoint Url is required.", null, BreakLevel.Fatal, nameof(EquifaxPreQualificationOfOneEndpoint)));

            // OAuth Scope for Endpoint
            if (string.IsNullOrWhiteSpace(EquifaxPreQualificationOfOneScope))
                validationIssues.Add(new ValidationIssue(this, "The OAuth Scope for PreQualification of One is required.", null, BreakLevel.Fatal, nameof(EquifaxPreQualificationOfOneScope)));

            return validationIssues.ToArray();
        }

        public void Initialize()
        {
            // Read the Settings here
            ModuleSettingsAccessor<EquifaxSettings>.GetSettings();
        }

        public override BaseActionType[] GetActions(AbstractUserContext userContext, EntityActionType[] types)
        {
            Account userAccount = userContext.GetAccount();

            FolderPermission permission = FolderService.Instance.GetAccountEffectivePermission(
                new SystemUserContext(), this.EntityFolderID, userAccount.AccountID);

            bool canAdministrate = FolderPermission.CanAdministrate == (FolderPermission.CanAdministrate & permission) ||
                                   userAccount.GetUserRights<PortalAdministratorModuleRight>() != null ||
                                   userAccount.IsAdministrator();

            if (canAdministrate)
                return new BaseActionType[]
                {
                    new EditEntityAction(GetType(), "Edit", null),
                };

            return new BaseActionType[0];
        }
    }
}