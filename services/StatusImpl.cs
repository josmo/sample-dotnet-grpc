using System.Threading.Tasks;
using Com.Samples.V1;
using Grpc.Core;

namespace sample_dotnet_grpc
{
    public class StatusImpl : InternalApplicationService.InternalApplicationServiceBase
    {
        public override Task<ApplicationStatusResponse> GetApplicationStatus(ApplicationStatusRequest request, ServerCallContext context)
        {
            var applicationId = request.ApplicationId;
            var myStatusResponse = new ApplicationStatusResponse();
            myStatusResponse.ApplicationStatus = "Active";
            myStatusResponse.CurrentNotes = "Nothing to report on " + applicationId;
            return Task.FromResult(myStatusResponse);
        }
    }
}