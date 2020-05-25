using System;
using System.Collections.Generic;

namespace CookbookDB
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
