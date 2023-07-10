using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using madden.Models;


[ApiController]
[Route("")]
public class ViewsController : Controller//Base
{
        
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpGet]
        public ViewResult LoginForm()
        {
            return View();
        }

        [Route("register")]
        [HttpGet]
        public ViewResult RegisterForm()
        {
            return View();
        }
}


