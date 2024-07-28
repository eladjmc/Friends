using Friends.DAL;
using Friends.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Friends.Controllers
{
    public class FriendsController : Controller
    {
        private readonly ILogger<FriendsController> _logger;

        public FriendsController(ILogger<FriendsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View(Data.Get.Friends.ToList());

        }


    }
}
