using System.Web.Mvc;

namespace Identity.Controllers
{
    //[Authorize(Roles = "admin, sales")]
    [Authorize(Users = "alex.gorban@outlook.com")]
    public class SecretController : Controller
    {
        public ContentResult Secret()
        {
            return Content("This is a secret...");
        }

        [AllowAnonymous]
        public ContentResult Over()
        {
            return Content("This is not a secret...");
        }
    }
}