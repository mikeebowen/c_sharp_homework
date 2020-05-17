using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace CookBookRepository
{
    class CookBookRepositoryRecipe
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Directions { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
