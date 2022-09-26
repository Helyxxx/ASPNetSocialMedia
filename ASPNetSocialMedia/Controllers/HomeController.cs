using ASPNetSocialMedia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNetSocialMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Feed()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult Weather()
        {
            return View();
        }
        public IActionResult Quote()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CompleteProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCompletedProfile()
        {
            UserDataModel umodel = new UserDataModel();

            umodel.UserId = HttpContext.Request.Form["user-id"].ToString();
            umodel.FirstName = HttpContext.Request.Form["first-name"].ToString();
            umodel.LastName = HttpContext.Request.Form["last-name"].ToString();
            umodel.ProfileImage = HttpContext.Request.Form["profile-picture"].ToString();
            umodel.Biography = HttpContext.Request.Form["bio"].ToString();

            int result = umodel.SaveDetails();

            if (result > 0)
            {
                ViewBag.Result = "Data Saved Successfully";
            }
            else
            {
                ViewBag.Result = "Something Went Wrong";
            }
            return View("Index");
        }

        public IActionResult SavePost()
        {
            Post p = new Post();

            p.WhoPosted = HttpContext.Request.Form["who-posted"].ToString();
            p.PostContent = HttpContext.Request.Form["post-content"].ToString();
            

            int result = p.CreatePost();

           
            return View("Index");
        }
    }
}