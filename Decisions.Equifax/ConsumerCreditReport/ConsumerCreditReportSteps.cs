using System;
using System.IO;
using System.Net;
using System.Text;
using Decisions.Equifax.ConsumerCreditReport.Request;
using Decisions.Equifax.ConsumerCreditReport.Response;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.CoreSteps;
using DecisionsFramework.Design.Flow.Mapping;
using DecisionsFramework.Design.Properties.Attributes;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Services.ContextData;
using Newtonsoft.Json;

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
            return Helpers.HTTPHelpers.ExecuteCreditReportRequest(request);
        }



        
    }
}