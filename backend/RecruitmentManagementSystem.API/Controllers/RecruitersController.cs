using Microsoft.AspNetCore.Mvc;

namespace RecruitmentManagementSystem.API.Controllers
{
    public class RecruitersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
