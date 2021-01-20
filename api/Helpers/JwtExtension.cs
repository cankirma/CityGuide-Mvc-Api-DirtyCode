using Microsoft.AspNetCore.Http;

namespace api.Helpers
{
    public static class JwtExtension
    {
        public static void AddApplicationError(this HttpResponse response,string message)
        {
            response.Headers.Add("Application Error",message);
            response.Headers.Add("access-control-allow-origin","*");
            response.Headers.Add("Access-Control-Expose-Header","Application-Error");
        }
    }
}