namespace api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Before Controller
            Console.WriteLine($"[{DateTime.Now}] Request: {context.Request.Method} {context.Request.Path}");

            await _next(context); // Call next middleware

            // After Controller
            Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
        } 
    }
}
