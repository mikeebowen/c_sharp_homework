using AutoMapper;
using CookbookApp.Models;
using CookbookRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBookApp.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Directions { get; set; }
        public string ImageURL { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (Ingredient ing in Ingredients)
                {
                    totalPrice += ing.Price;
                }
                return String.Format("{0:C}", totalPrice);
            }
        }
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(config => config.CreateMap<Recipe, CookbookRepositoryRecipe>().ReverseMap());
        private static IMapper mapper = mapperConfiguration.CreateMapper();
        public CookbookRepositoryRecipe ToRepositoryModel()
        {
            return new CookbookRepositoryRecipe()
            {
                ID = this.ID,
                Title = this.Title,
                Author = this.Author,
                Directions = this.Directions,
                ImageURL = this.ImageURL,
                Ingredients = this.Ingredients.Select(ing => ing.ToRepositoryModel()).ToList()
            };
        }
        public static Recipe ToModel(CookbookRepositoryRecipe repositoryRecipe)
        {
            return new Recipe()
            {
                ID = repositoryRecipe.ID,
                Title = repositoryRecipe.Title,
                Author = repositoryRecipe.Author,
                Directions = repositoryRecipe.Directions,
                ImageURL = repositoryRecipe.ImageURL,
                Ingredients = repositoryRecipe.Ingredients.Select(ing => Ingredient.ToModel(ing)).ToList()
            };
        }
    }
}
