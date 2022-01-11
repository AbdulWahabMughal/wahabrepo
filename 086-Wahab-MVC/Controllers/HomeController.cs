using _086_Wahab_MVC.Data;
using _086_Wahab_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _086_Wahab_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult student()
        {
            return View();
        }
        private readonly DataDbContext _dataDbContext;
        private List<Contact> My_con;

        public List<Contact> My_Contact { get; private set; }
        public object Contact_me { get; private set; }

        public HomeController(DataDbContext dataDbContext)
        {

            _dataDbContext = dataDbContext;


        }
        public IActionResult Contactform()
        {
            My_con = _dataDbContext.contacts.ToList();
            return View(My_con);
        }
        [HttpPost]
        public object Contactform(Contact contact)
        {
            try
            {
                _dataDbContext.contacts.Add(contact);
                _dataDbContext.SaveChanges();
                ViewData["message"] = "Data Sucessfully Saved";
            }
            catch(Exception ex)
            {
                ViewData["message"] = "data not sucessfully saved";
            }

            return RedirectToAction("contactform");
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var edit_std = _dataDbContext.contacts.Find(Id);
            return View(edit_std);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var edit_student = _dataDbContext.contacts.Find(contact.Id);
            if (edit_student != null)
            {
                edit_student.fname= contact.fname;
                edit_student.Quantity = contact.Quantity;
                edit_student.Description = contact.Description;
                edit_student.Price = contact.Price;
                _dataDbContext.contacts.Update(edit_student);
                _dataDbContext.SaveChanges();
            }
            return RedirectToAction("Contactform");
        }

        public IActionResult Delete(int? Id)
        {
            var del_student = _dataDbContext.contacts.Find(Id);
            _dataDbContext.contacts.Remove(del_student);
            _dataDbContext.SaveChanges();
            return RedirectToAction("Contactform");
        }

        public IActionResult View(int? Id)
        {
            return View(_dataDbContext.contacts.Find(Id));
        }

    }
}
