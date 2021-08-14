using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Employee.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Index(Employee.Areas.Admin.Models.Admin admin)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"/app/tt.json");

            FirestoreDb db = FirestoreDb.Create("employee-bed05");
            DocumentReference docRef = db.Collection("Admin").Document("9Hx6VUoVQF96UqSYCG5W");
   
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
             var adminFirestore = snapshot.ConvertTo<Employee.Areas.Admin.Models.Admin>();

            if (admin.UserName == adminFirestore.UserName && admin.Password == adminFirestore.Password)
            {
                return View("Dashboard");
            }
            return View("AccessDenied");
        }
    }
}
