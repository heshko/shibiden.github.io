using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Areas.Admin.Models
{
    [FirestoreData]
    public class Admin
    {
        [FirestoreProperty]
        public string UserName { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
    }
}
