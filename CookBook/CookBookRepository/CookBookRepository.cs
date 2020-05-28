//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookbookRepository
{
    public class CookBookRepository
    {
        public List<CookbookRepositoryRecipe> GetAll()
        {
            return DatabaseManager.Instance.Recipe
                .Include(rec => rec.Ingredient)
                .Select(r => new CookbookRepositoryRecipe
                {
                    ID = r.Id,
                    Author = r.Author,
                    Directions = r.Directions,
                    Title = r.Title,
                    Ingredients = r.Ingredient.Select(i => new CookbookRepositoryIngredient
                    {
                        ID = i.Id,
                        Name = i.Name
                    }).ToList()
                })
                .ToList();
        }
    }
}
