using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Equifax.PrequalificationOfOne
{
    [AutoRegisterMethodsOnClass(true, "Integration/Equifax/Pre-qualification of One")]
    public class PrequalificationOfOneSteps 
    {
        private static readonly Log log = new Log(EquifaxConstants.LogCat);
        
        /// <summary>
        /// Step: Get Pre-qualification of One (Integration/Equifax/Consumer Credit Report/Pre-qualification of One)
        /// </summary>
        public static ConsumerCreditReportResponse GetPrequalificationOfOne(ConsumerCreditReportRequest request)
        {
            string scope = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxPrequalificationOfOneScope;
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxPrequalificationOfOneEndpoint;
            return EquifaxUtilities.ExecuteCreditReportRequest(request, scope, requestUrl);
        }
        
    }
}