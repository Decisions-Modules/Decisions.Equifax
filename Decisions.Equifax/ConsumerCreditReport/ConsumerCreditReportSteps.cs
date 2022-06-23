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
        private static readonly Log log = new Log(EquifaxConstants.LogCat);
        
        /// <summary>
        /// Step: Get Consumer Credit Report (Integration/Equifax/Consumer Credit Report/Get Consumer Credit Report)
        /// </summary>
        public static ConsumerCreditReportResponse GetConsumerCreditReport(ConsumerCreditReportRequest request)
        {
            string scope = ModuleSettingsAccessor<EquifaxSettings>.GetSettings().EquifaxConsumerCreditReportScope;
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.GetSettings().EquifaxConsumerCreditReportEndpoint;
            if (string.IsNullOrWhiteSpace(scope)|| string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            return EquifaxUtilities.ExecuteCreditReportRequest(request, scope, requestUrl);
        }
    }
}