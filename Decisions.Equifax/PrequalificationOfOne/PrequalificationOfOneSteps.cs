using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.PreQualificationOfOne.Response;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Equifax.PrequalificationOfOne
{
    [AutoRegisterMethodsOnClass(true, "Integration/Equifax/Pre-qualification of One")]
    public class PreQualificationOfOneSteps 
    {
        /// <summary>
        /// Step: Get Pre-qualification of One (Integration/Equifax/Consumer Credit Report/Pre-qualification of One)
        /// </summary>
        public static PreQualificationOfOneResponse GetPrequalificationOfOne(ConsumerCreditReportRequest request)
        {
            string scope = ModuleSettingsAccessor<EquifaxSettings>.GetSettings().EquifaxPreQualificationOfOneScope;
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.GetSettings().EquifaxPreQualificationOfOneEndpoint;
            if (string.IsNullOrWhiteSpace(scope)|| string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            return EquifaxUtilities.ExecutePrequalificationRequest(request, scope, requestUrl);
        }
    }
}