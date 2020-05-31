//using Microsoft.EntityFrameworkCore;
using CookbookDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
                    ImageURL = r.ImageUrl,
                    Ingredients = r.Ingredient.Select(i => new CookbookRepositoryIngredient
                    {
                        ID = i.Id,
                        Name = i.Name,
                        Price = i.Price,
                        ImageURL = i.ImageUrl
                    }).ToList()
                })
                .ToList();
        }
        public CookbookRepositoryRecipe Add(CookbookRepositoryRecipe cookbookRepositoryRecipe)
        {
            Recipe recipe = toDatabaseRecipe(cookbookRepositoryRecipe);

            DatabaseManager.Instance.Recipe.Add(recipe);
            DatabaseManager.Instance.SaveChanges();
            cookbookRepositoryRecipe.ID = recipe.Id;
            return cookbookRepositoryRecipe;
        }

        public bool Update(CookbookRepositoryRecipe cookbookRepositoryRecipe)
        {
            Recipe originalRecipe = DatabaseManager.Instance.Recipe.Find(cookbookRepositoryRecipe.ID);
            if (originalRecipe != null)
            {
                DatabaseManager.Instance.Entry(originalRecipe).CurrentValues.SetValues(toDatabaseRecipe(cookbookRepositoryRecipe));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }
            return false;
        }

        private Recipe toDatabaseRecipe(CookbookRepositoryRecipe cookbookRepositoryRecipe)
        {
            Recipe recipe = new Recipe
            {
                Id = cookbookRepositoryRecipe.ID,
                Title = cookbookRepositoryRecipe.Title,
                Author = cookbookRepositoryRecipe.Author,
                Directions = cookbookRepositoryRecipe.Directions,
                ImageUrl = cookbookRepositoryRecipe.ImageURL,
                Ingredient = cookbookRepositoryRecipe.Ingredients.Select(ing => new Ingredient
                {
                    Name = ing.Name,
                    Price = ing.Price,
                    ImageUrl = ing.ImageURL
                }).ToList()
            };
            return recipe;
        }
    }
}
