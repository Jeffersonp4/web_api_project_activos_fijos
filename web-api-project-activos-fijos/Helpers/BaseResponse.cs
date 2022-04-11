namespace web_api_project_activos_fijos.Helpers
{
    public class BaseResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


        public BaseResponse() { }

        public BaseResponse(string message, object data, bool ok = false)
        {
            Ok = ok;
            Message = message;
            Data = data;
        }
    }
}
