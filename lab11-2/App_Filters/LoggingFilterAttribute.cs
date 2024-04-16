using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lab11_2.App_Filters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Запис імені методу дії та часу виконання
            var controllerDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerDescriptor != null)
            {
                string logEntry = $"Action Method: {controllerDescriptor.ActionName} | Execution Time: {DateTime.Now}";
                File.AppendAllText("log.txt", logEntry + Environment.NewLine);
            }

            base.OnActionExecuted(context);
        }
    }
}
