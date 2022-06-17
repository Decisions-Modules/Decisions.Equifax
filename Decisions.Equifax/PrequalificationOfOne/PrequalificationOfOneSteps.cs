using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using Decisions.Equifax.PrequalificationOfOne.Request;
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
        public static ConsumerCreditReportResponse GetPrequalificationOfOne(PrequalificationOfOneRequest request)
        {
            string scope = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxPrequalificationOfOneScope;
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxPrequalificationOfOneEndpoint;
            string stepCalled = "Prequalification";
            return EquifaxUtilities.ExecuteCreditReportRequest(request, scope, requestUrl, stepCalled);
        }
    }
}