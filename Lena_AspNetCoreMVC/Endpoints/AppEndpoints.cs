namespace Lena_AspNetCoreMVC.Endpoints
{
    public static class AppEndpoints
    {
        public static void UseApplicationEndpoints(this WebApplication app)
        {
            app.MapControllerRoute("app-login", "login", new { controller = "Login", action = "Index" });
            app.MapControllerRoute("app-LoginVerify", "login-verify", new { controller = "Login", action = "LoginVerify" });
            app.MapControllerRoute("app-forms", "forms", new { controller = "FormManagement", action = "Index" });
            app.MapControllerRoute("app-form-details", "forms/{formId}", new { controller = "FormManagement", action = "FormDetailed" });
        }
    }
}
