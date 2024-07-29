using Friends.DAL;
using Friends.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return View(Data.Get.Friends.Include((f)=>f.Images).ToList());

        }
        public IActionResult Create()
        {
            return View(new Friend());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Friend friend)
        {

                Data.Get.Friends.Add(friend);
                Data.Get.SaveChanges();
                return RedirectToAction("Index");

         
        }


    }
}
