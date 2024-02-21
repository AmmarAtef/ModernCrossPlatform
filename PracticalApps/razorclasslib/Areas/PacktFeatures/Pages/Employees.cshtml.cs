using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Common.Models;

namespace razorclasslib.MyFeature.Pages
{
    public class EmployeesPageModel : PageModel
    {
        public Employee[] Employees { get; set; } = null!;
        private NorthwindContext db;

        public EmployeesPageModel(NorthwindContext northwindContext)
        {
            db = northwindContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Employees";
            Employees = db.Employees.OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName).ToArray();
        }


    }
}