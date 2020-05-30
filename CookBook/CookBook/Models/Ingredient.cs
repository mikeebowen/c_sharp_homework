using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CookBookApp.Models;
using CookbookRepository;


namespace CookbookApp.Models
{
    class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(config => config.CreateMap<Ingredient, CookbookRepositoryIngredient>().ReverseMap());
        private static IMapper mapper = mapperConfiguration.CreateMapper();
        public CookbookRepositoryIngredient ToRepositoryModel()
        {
            return mapper.Map<CookbookRepositoryIngredient>(this);
        }
        public static Ingredient ToModel(CookbookRepositoryIngredient repositoryIngredient)
        {
            return mapper.Map<Ingredient>(repositoryIngredient);
        }
    }
}
