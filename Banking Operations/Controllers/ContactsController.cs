using Banking_Operations.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Operations.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Check(ContactsModel CM)
        {
            
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        
    }
        
    }
}
