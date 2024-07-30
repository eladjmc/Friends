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

            return View(Data.Get.Friends.Include((f) => f.Images).ToList());

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
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            Friend? friend = Data.Get.Friends.Include(f => f.Images).FirstOrDefault(f => f.Id == id);
            if (friend == null) return RedirectToAction("Index");

            return View(friend);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddImage(int? id, IFormFile image)
        {
            if (id == null) return RedirectToAction("Index");
            if (image == null) return RedirectToAction("Details", new { id = id });
            Friend? friend = Data.Get.Friends.Include(f => f.Images).FirstOrDefault(f => f.Id == id);
            if (friend == null) return RedirectToAction("Index");
            friend.AddImage(image);
            Data.Get.SaveChanges();

            return RedirectToAction("Details", new {id=id});
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            Friend? friendToDelete = Data.Get.Friends.Include((f) => f.Images).FirstOrDefault(f => f.Id == id);
            if (friendToDelete == null) return RedirectToAction("Index");

            Data.Get.Remove(friendToDelete);
            Data.Get.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
