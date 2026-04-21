using System.Collections.Generic;
using System.ComponentModel;
using DecisionsFramework;
using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.Design.Properties.Attributes;
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
        [PropertyClassification(0, "OAuth Url", "OAuth Settings")]
        public string EquifaxOAuthUrl { get; set; }

        [ORMField]
        [PropertyClassification(1, "API Client ID", "OAuth Settings")]
        public string EquifaxClientId { get; set; }

        [ORMField]
        [PropertyClassification(2, "API Client Secret", "OAuth Settings")]
        public string EquifaxClientSecret { get; set; }
        
        [ORMField]
        [PropertyClassification(3, "API Endpoint Url", "Consumer Credit Report")]
        public string EquifaxConsumerCreditReportEndpoint { get; set; }

        [ORMField]
        [PropertyClassification(4, "OAuth Scope", "Consumer Credit Report")]
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
