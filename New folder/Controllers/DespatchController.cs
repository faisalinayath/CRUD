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

       public IActionResult StoreDataToExcel(dispatch formData)
        {
            // Set the file path where the Excel file will be stored
            var filePath = @"C:\New folder\FormEntries.xlsx";

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
                existingWorksheet.Cells[lastUsedRow + 1, 1].Value = formData.To;
                existingWorksheet.Cells[lastUsedRow + 1, 2].Value = formData.CustomerCellNo;
                existingWorksheet.Cells[lastUsedRow + 1, 3].Value = formData.ItemType;
                existingWorksheet.Cells[lastUsedRow + 1, 4].Value = formData.VehicleNumber;
                existingWorksheet.Cells[lastUsedRow + 1, 5].Value = formData.QuantityWeight;
                existingWorksheet.Cells[lastUsedRow + 1, 6].Value = formData.PriceInFigures;
                existingWorksheet.Cells[lastUsedRow + 1, 7].Value = formData.PriceInWords;
                existingWorksheet.Cells[lastUsedRow + 1, 8].Value = formData.TruckNo;
                existingWorksheet.Cells[lastUsedRow + 1, 9].Value = formData.LorryFreight;
                existingWorksheet.Cells[lastUsedRow + 1, 10].Value = formData.AdvancePaid;
                existingWorksheet.Cells[lastUsedRow + 1, 11].Value = formData.BalancePayable;
                existingWorksheet.Cells[lastUsedRow + 1, 12].Value = formData.GrossWeight;
                existingWorksheet.Cells[lastUsedRow + 1, 13].Value = formData.TareWeight;
                existingWorksheet.Cells[lastUsedRow + 1, 14].Value = formData.NetWeight;
                existingWorksheet.Cells[lastUsedRow + 1, 15].Value = formData.Camp;
                existingWorksheet.Cells[lastUsedRow + 1, 16].Value = formData.DriverName;
                existingWorksheet.Cells[lastUsedRow + 1, 17].Value = formData.DriverCellNo;
                existingWorksheet.Cells[lastUsedRow + 1, 18].Value = formData.Owner;

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
                worksheet.Cells[1, 1].Value = "To";
                worksheet.Cells[1, 2].Value = "Customer Cell No";
                worksheet.Cells[1, 3].Value = "Item Type";
                worksheet.Cells[1, 4].Value = "Vehicle Number";
                worksheet.Cells[1, 5].Value = "Quantity Weight";
                worksheet.Cells[1, 6].Value = "Price In Figures";
                worksheet.Cells[1, 7].Value = "Price In Words";
                worksheet.Cells[1, 8].Value = "Truck Number";
                worksheet.Cells[1, 9].Value = "Lorry Frieght";
                worksheet.Cells[1, 10].Value = "Advanced Paid";
                worksheet.Cells[1, 11].Value = "Balance Payable";
                worksheet.Cells[1, 12].Value = "Gross Weight";
                worksheet.Cells[1, 13].Value = "Tare Weight";
                worksheet.Cells[1, 14].Value = "Net Weight";
                worksheet.Cells[1, 15].Value = "Camp";
                worksheet.Cells[1, 16].Value = "Driver Name";
                worksheet.Cells[1, 17].Value = "Driver Cell Number";
                worksheet.Cells[1, 18].Value = "Owner";


                // Write the form data to the second row


                worksheet.Cells[2, 1].Value = formData.To;
                worksheet.Cells[2, 2].Value = formData.CustomerCellNo;
                worksheet.Cells[2, 3].Value = formData.ItemType;
                worksheet.Cells[2, 4].Value = formData.VehicleNumber;
                worksheet.Cells[2, 5].Value = formData.QuantityWeight;
                worksheet.Cells[2, 6].Value = formData.PriceInFigures;
                worksheet.Cells[2, 7].Value = formData.PriceInWords;
                worksheet.Cells[2, 8].Value = formData.TruckNo;
                worksheet.Cells[2, 9].Value = formData.LorryFreight;
                worksheet.Cells[2, 10].Value = formData.AdvancePaid;
                worksheet.Cells[2, 11].Value = formData.BalancePayable;
                worksheet.Cells[2, 12].Value = formData.GrossWeight;
                worksheet.Cells[2, 13].Value = formData.TareWeight;
                worksheet.Cells[2, 14].Value = formData.NetWeight;
                worksheet.Cells[2, 15].Value = formData.Camp;
                worksheet.Cells[2, 16].Value = formData.DriverName;
                worksheet.Cells[2, 17].Value = formData.DriverCellNo;
                worksheet.Cells[2, 18].Value = formData.Owner;

                // Save the Excel package to the file path
                package.SaveAs(new FileInfo(filePath));
            }

            // Return a success message
            return Content("Form data stored successfully.");
        }

    }
}
