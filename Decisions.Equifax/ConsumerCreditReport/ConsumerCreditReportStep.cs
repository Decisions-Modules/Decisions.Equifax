using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Equifax.ConsumerCreditReport
{
    [AutoRegisterMethodsOnClass(true, "Integration/Equifax/Consumer Credit Report")]
    public class ConsumerCreditReportSteps
    {
        /// <summary>
        /// Step: Get Consumer Credit Report (Integration/Equifax/Consumer Credit Report/Get Consumer Credit Report)
        /// </summary>
        public static ConsumerCreditReportResponse GetConsumerCreditReport(ConsumerCreditReportRequest request)
        {
            EquifaxSettings equifaxSettings = ModuleSettingsAccessor<EquifaxSettings>.GetSettings();
            if (string.IsNullOrWhiteSpace(equifaxSettings.EquifaxConsumerCreditReportScope)|| string.IsNullOrWhiteSpace(equifaxSettings.EquifaxConsumerCreditReportEndpoint))
            {
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            
            return EquifaxUtilities.ExecuteCreditReportRequest(request, equifaxSettings.EquifaxConsumerCreditReportScope, equifaxSettings.EquifaxConsumerCreditReportEndpoint);
        }
    }
}