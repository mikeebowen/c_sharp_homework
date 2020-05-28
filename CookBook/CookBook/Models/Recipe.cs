using AutoMapper;
using CookbookApp.Models;
using CookbookRepository;
using System;
using System.Collections.Generic;
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
            return mapper.Map<CookbookRepositoryRecipe>(this);
        }
        public static Recipe ToModel(CookbookRepositoryRecipe repositoryRecipe)
        {
            return mapper.Map<Recipe>(repositoryRecipe);
        }
    }
}
