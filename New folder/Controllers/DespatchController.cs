using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using FareedFruits.Models;

namespace FareedFruits.Controllers
{
	public class DespatchController : Controller
	{
        static DespatchController()
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public IActionResult Index()
		{
			return View();
		}

        public IActionResult StoreDataToExcel(YourFormDataModel formData)
        {
            // Set the file path where the Excel file will be stored
            var filePath = @"D:\New folder\FormEntries.xlsx";

            // Create a new Excel package or load the existing one
            ExcelPackage package;
            if (System.IO.File.Exists(filePath))
            {
                // Load the existing Excel file
                var existingPackage = new ExcelPackage(new FileInfo(filePath));
                // Get the first worksheet from the existing package
                var existingWorksheet = existingPackage.Workbook.Worksheets[0];

                // Get the last used row in the worksheet
                var lastUsedRow = existingWorksheet.Dimension?.End?.Row ?? 1;

                // Write the form data to the next available row in the worksheet
                existingWorksheet.Cells[lastUsedRow + 1, 1].Value = formData.Field1;
                existingWorksheet.Cells[lastUsedRow + 1, 2].Value = formData.Field2;

                // Save the changes to the existing Excel file
                existingPackage.Save();
            }
            else
            {
                // Create a new Excel file
                package = new ExcelPackage();

                // Add a new worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Write the header row
                worksheet.Cells[1, 1].Value = "Field 1";
                worksheet.Cells[1, 2].Value = "Field 2";

                // Write the form data to the second row
                worksheet.Cells[2, 1].Value = formData.Field1;
                worksheet.Cells[2, 2].Value = formData.Field2;

                // Save the Excel package to the file path
                package.SaveAs(new FileInfo(filePath));
            }

            // Return a success message
            return Content("Form data stored successfully.");
        }

    }
}
