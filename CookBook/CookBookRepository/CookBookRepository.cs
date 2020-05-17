using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBookRepository
{
    class CookBookRepository
    {
        public static List<CookBookRepositoryRecipe> GetAll()
        {
            return DatabaseManager.Instance.Recipe.Select(t => new CookBookRepositoryRecipe
            {
                ID = t.Id,
                Author = t.Author,
                Directions = t.Directions,
                Title = t.Title
            }).ToList();
        }
    }
}
