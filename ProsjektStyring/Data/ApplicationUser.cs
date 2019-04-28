using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public DateTime RegistrationDate { get; set; }
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string FullName { get { return string.Format("{0} {1}", FullName, LastName); } }
        [PersonalData]
        public bool Active { get; set; }
        [PersonalData]
        public string EmployeeId { get; set; }


    }
}
