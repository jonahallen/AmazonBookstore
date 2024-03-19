using AmazonBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmazonBookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var booksData = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);
            
            return View(booksData);
        }

    }
}
