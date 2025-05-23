﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Data.Entities
{
    public class Adopter : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PreferredCatBreed { get; set; }
        public string PreferredCatAge { get; set; }
        public string PreferredCatPersonality { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
        public virtual ICollection<Cat>? AdoptedCats { get; set; } = new List<Cat>();
    }
}
