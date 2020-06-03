using AutoMapper;
using CookbookApp.Models;
using CookbookRepository;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CookBookApp.Models
{
    public class Recipe : IDataErrorInfo, INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Directions { get; set; }
        public string ImageURL { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
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
        private string titleError { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Error => "Never Used";
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Title":
                        {
                            TitleError = "";

                            if (Title == null || string.IsNullOrEmpty(Title))
                            {
                                TitleError = "Name cannot be empty.";
                            }

                            return TitleError;
                        }
                }

                return null;
            }
        }
        public string TitleError
        {
            get
            {
                return titleError;
            }
            set
            {
                if (titleError != value)
                {
                    titleError = value;
                    OnPropertyChanged("TitleError");
                }
            }
        }
        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
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
                Ingredients = new ObservableCollection<Ingredient>(repositoryRecipe.Ingredients.Select(ing => Ingredient.ToModel(ing)).ToList().AsEnumerable())
            };
        }
    }
}
