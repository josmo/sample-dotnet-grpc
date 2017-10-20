using System;
using System.Linq;
using System.Threading.Tasks;
using Com.Samples.V1;
using Grpc.Core;

namespace sample_dotnet_grpc
{
    public class StatusImpl : InternalApplicationService.InternalApplicationServiceBase
    {
        public override Task<ApplicationStatusResponse> GetApplicationStatus(ApplicationStatusRequest request, ServerCallContext context)
        {
            
            var headers = context.RequestHeaders;
            var token = headers.Where(item => item.Key == "token").Select(item => item.Value).FirstOrDefault();
            if (token != null)
            {
                //Congrats you have a token on the metadata headers ;) This is a great way to pass jwt tokens
            }
            
            var applicationId = request.ApplicationId;
            var myStatusResponse = new ApplicationStatusResponse();
            myStatusResponse.ApplicationStatus = "Active";
            myStatusResponse.CurrentNotes = "Nothing to report on " + applicationId;
            myStatusResponse.StatusId = 1;
            return Task.FromResult(myStatusResponse);
        }
    }
}