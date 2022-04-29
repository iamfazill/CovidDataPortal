using CovidDataPortalApi.Models.Enum;

namespace CovidDataPortalApi.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Success = true;
            Message = "Request Completed Successfully";
            ErrorMessage = "";
            Data = null;
            ResponseCode = ResponseCode.SUCCESS;
        }
        public ResponseCode ResponseCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}

