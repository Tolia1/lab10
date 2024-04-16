using Microsoft.AspNetCore.Mvc.Filters;

namespace lab11_2.App_Filters
{
    public class UserCountFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userIP = null;
            var httpContext = context.HttpContext;

            if (httpContext != null)
            {
                var ipAddress = httpContext.Connection.RemoteIpAddress;
                if (ipAddress != null)
                {
                    userIP = ipAddress.ToString();
                }
            }

            using (StreamReader reader = new StreamReader("users.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == userIP)
                    {
                        return;
                    }
                }
            }

            // Запис IP-адреси користувача
            File.AppendAllText("users.txt", userIP + Environment.NewLine);

            base.OnActionExecuting(context);
        }
    }

}
