using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace CookbookRepository
{
    public class CookbookRepositoryRecipe
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Directions { get; set; }
        public List<CookbookRepositoryIngredient> Ingredients { get; set; }
    }
}
