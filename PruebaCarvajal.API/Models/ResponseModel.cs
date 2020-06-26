namespace PruebaCarvajal.API.Models
{
    public class ResponseModel
    {
        public int HttpResponse { get; set; }
        public object Response { get; set; }
        public string ErrorResponse { get; set; }
    }
}
