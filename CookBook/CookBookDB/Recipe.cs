using System;
using System.Collections.Generic;

namespace CookbookDB
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Directions { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
