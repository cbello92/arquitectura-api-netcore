using System;

namespace ArquitecturaAPI.Responses
{
    public class ApiResponse
    {
        public ApiResponse(Object data)
        {
            Data = data;
            success = true;
        }

        public bool success { get; set; }
        public Object Data { get; set; }
    }
}
