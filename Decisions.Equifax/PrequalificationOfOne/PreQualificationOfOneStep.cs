using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.PreQualificationOfOne.Response;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Equifax.PrequalificationOfOne
{
    [AutoRegisterMethodsOnClass(true, "Integration/Equifax/PreQualification")]
    public class PreQualificationOfOneStep 
    {
        /// <summary>
        /// Step: Get Pre-qualification of One (Integration/Equifax/Consumer Credit Report/Pre-qualification of One)
        /// </summary>
        public static PreQualificationOfOneResponse GetPreQualificationOfOne(ConsumerCreditReportRequest request)
        {
            EquifaxSettings equifaxSettings = ModuleSettingsAccessor<EquifaxSettings>.GetSettings();
            if (string.IsNullOrWhiteSpace(equifaxSettings.EquifaxPreQualificationOfOneScope)|| string.IsNullOrWhiteSpace(equifaxSettings.EquifaxPreQualificationOfOneEndpoint))
            {
                throw new LoggedException(EquifaxConstants.SETTINGS_CONFIGURATION_EXCEPTION);
            }
            
            return EquifaxUtilities.ExecutePreQualificationRequest(request, equifaxSettings.EquifaxPreQualificationOfOneScope, equifaxSettings.EquifaxPreQualificationOfOneEndpoint);
        }
    }
}