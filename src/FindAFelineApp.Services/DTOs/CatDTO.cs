using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.DTOs
{
    public class CatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        [Range(0, 20, ErrorMessage = "Age can't be a negative number or higher than 20!")]
        public int Age { get; set; }
        public string Color { get; set; }
        public string Personality { get; set; }
        [Display(Name="Image")]
        public string ImageUrl { get; set; }
    }
}
