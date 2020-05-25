//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            return DatabaseManager.Instance.Recipe
                .Include(rec => rec.Ingredient)
                .Select(r => new CookBookRepositoryRecipe
                {
                    ID = r.Id,
                    Author = r.Author,
                    Directions = r.Directions,
                    Title = r.Title
                })
                .ToList();
        }
    }
}
