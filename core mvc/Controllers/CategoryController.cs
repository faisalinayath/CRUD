  [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Property model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (image != null)
                {
                    string uploadsDir = Path.Combine(_hostEnvironment.WebRootPath, "ImagesUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsDir, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }

                // Save the property details to the database
                Property property = new Property
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Image_Path = uniqueFileName != null ? "images/" + uniqueFileName : null,
                    Seller_Name = model.Seller_Name,
                    Seller_Phone = model.Seller_Phone,
                    Seller_Email_Id = model.Seller_Email_Id
                };

                _db.Property.Add(property);
                _db.SaveChanges();

                return RedirectToAction("Index", "Properties");
            }

            return View(model);
        }
    }     //Severity	Code	Description	Project	File	Line	Suppression State
Error	CS0103	The name '_hostEnvironment' does not exist in the current context	PropDealsNew	C:\Users\finayath\source\repos\PropDealsNew\PropDealsNew\Controllers\PropertiesController.cs	37	Active
