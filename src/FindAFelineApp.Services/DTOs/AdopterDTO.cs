using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.DTOs
{
    public class AdopterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(18, 1000, ErrorMessage = "Age not appropriate!")]
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PreferredCatBreed { get; set; }
        [Range(0, 20, ErrorMessage = "Please pick an age between 0 and 20!" )]
        public string PreferredCatAge { get; set; }
        public string PreferredCatPersonality { get; set; }
        public int Id { get; set; }
        public string? UserId { get; set; }
        public List<CatDTO> AdoptedCats { get; set; }
    }
}