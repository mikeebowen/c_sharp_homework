using AutoMapper;
using CookbookApp.Models;
using CookbookRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBookApp.Models
{
    class Recipe
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Directions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
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
                Ingredients = repositoryRecipe.Ingredients.Select(ing => Ingredient.ToModel(ing)).ToList()
            };
        }
    }
}
