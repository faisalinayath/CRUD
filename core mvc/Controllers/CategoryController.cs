
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Azure;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using Microsoft.EntityFrameworkCore.Storage;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        //This line of code defines a private field named _db of type ApplicationDbContext. The readonly keyword
        //indicates that this field can only be assigned a value once (in the constructor) and cannot be changed afterwards.


        //In this code, ApplicationDbContext is a class that represents a connection to a database.The _db field in the
        //CategoryController class is a way for the controller to access this database connection.
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        //The IActionResult interface represents the result of an action method that can be executed by the web framework.
        //It provides a way to specify the type of response that will be returned to the client.
        public IActionResult Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            //In the provided code, Categories is likely a table name, and Category is the
            //corresponding model class that represents the structure of each record in that table.

            //_db.Categories.ToList() is a LINQ query that retrieves all the records from the Categories table
            //in the database and converts them into a list of Category objects
            return View(categoryList);
        }


        //GET REQUEST
        public IActionResult Create_data()
        {
            return View();

        }

        //POST REQUEST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_data(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())        //cutom validation
            {
                ModelState.AddModelError("CustomeError","The Display Order Cannot Exactly Match The Name");
            }
            // In.NET MVC Core, ModelState is a class that is used to store information about the state of a
            // model during model binding and validation processes.

            //When a user submits a form in an MVC application, the values entered in the form fields are bound
            //to the corresponding properties of a model object. The ModelState object tracks the binding and
            //validation process and provides information about any errors or validation failures that occurred
            //during this process.

            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
        }
            return View(obj);
    }

        
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())        //cutom validation
            {
                ModelState.AddModelError("CustomeError", "The Display Order Cannot Exactly Match The Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int? id)
        //cannot have the same name Delete becuse edit and delete have the same parameters
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
          
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
      
        }
    }
}
