using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.DTOs
{
    public class FosterParentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //how add age restriction
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}
