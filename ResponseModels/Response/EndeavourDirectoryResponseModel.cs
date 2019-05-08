using ApiModels.Response;

namespace Endeavour.Controllers
{
    public class EndeavourDirectoryResponseModel : ActorDirectoryResponseModel
    {
        public ResponseEndeavour[] Endeavours { get; set; }
    }

    public class ResponseEndeavour
    {
    }
}