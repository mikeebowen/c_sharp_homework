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
                foreach (CookbookRepositoryIngredient ing in cookbookRepositoryRecipe.Ingredients)
                {
                    if (ing.ID == 0) {
                        originalRecipe.Ingredient.Add(new Ingredient
                        {
                            Name = ing.Name,
                            Price = ing.Price,
                            ImageUrl = ing.ImageURL
                        });
                    }
                }
                DatabaseManager.Instance.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Remove(CookbookRepositoryRecipe cookbookRepositoryRecipe)
        {
            IQueryable<Recipe> recipes = DatabaseManager.Instance.Recipe.Where(r => r.Id == cookbookRepositoryRecipe.ID);
            if (recipes.Count() == 0)
            {
                return false;
            }
            Recipe recipe = recipes.First();
            if (cookbookRepositoryRecipe.Ingredients.Count() > 0)
            {
                foreach (CookbookRepositoryIngredient ing in cookbookRepositoryRecipe.Ingredients)
                {
                    IQueryable<Ingredient> ingredients = DatabaseManager.Instance.Ingredient.Where(i => i.Id == ing.ID);
                    DatabaseManager.Instance.Ingredient.Remove(ingredients.First());
                }
                DatabaseManager.Instance.SaveChanges();
            }
            DatabaseManager.Instance.Recipe.Remove(recipes.First());
            DatabaseManager.Instance.SaveChanges();
            return true;
        }
        private Ingredient saveIngredient(CookbookRepositoryIngredient cookbookRepositoryIngredient)
        {
            Ingredient ingredient = new Ingredient
            {
                Id = cookbookRepositoryIngredient.ID,
                Name = cookbookRepositoryIngredient.Name,
                Price = cookbookRepositoryIngredient.Price,
                ImageUrl = cookbookRepositoryIngredient.ImageURL
            };
            DatabaseManager.Instance.Ingredient.Add(ingredient);
            return ingredient;
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
        private Ingredient toDatabaseIngredient(CookbookRepositoryIngredient cookbookRepositoryIngredient)
        {
            Ingredient recipe = new Ingredient
            {
                Id = cookbookRepositoryIngredient.ID,
                Name = cookbookRepositoryIngredient.Name,
                Price = cookbookRepositoryIngredient.Price,
                 ImageUrl = cookbookRepositoryIngredient.ImageURL
            };
            return recipe;
        }
    }
}
