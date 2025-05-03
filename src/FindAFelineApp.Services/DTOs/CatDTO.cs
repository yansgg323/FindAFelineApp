using System;
using System.Collections.Generic;
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
        public int Age { get; set; }
        public string Color { get; set; }
        public string Personality { get; set; }
        public string ImageUrl { get; set; }
    }
}
