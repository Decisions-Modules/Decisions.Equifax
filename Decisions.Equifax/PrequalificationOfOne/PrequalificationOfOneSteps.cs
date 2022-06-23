using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using Decisions.Equifax.PrequalificationOfOne.Request;
using Decisions.Equifax.PreQualificationOfOne.Response;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.Equifax.PrequalificationOfOne
{
    [AutoRegisterMethodsOnClass(true, "Integration/Equifax/Pre-qualification of One")]
    public class PreQualificationOfOneSteps 
    {
        private static readonly Log log = new Log(EquifaxConstants.LogCat);
        
        /// <summary>
        /// Step: Get Pre-qualification of One (Integration/Equifax/Consumer Credit Report/Pre-qualification of One)
        /// </summary>
        public static PreQualificationOfOneResponse GetPrequalificationOfOne(ConsumerCreditReportRequest request)
        {
            string scope = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxPreQualificationOfOneScope;
            string requestUrl = ModuleSettingsAccessor<EquifaxSettings>.Instance.EquifaxPreQualificationOfOneEndpoint;
            string stepCalled = "PreQualification";
            return EquifaxUtilities.ExecutePrequalificationRequest(request, scope, requestUrl);
        }
    }
}