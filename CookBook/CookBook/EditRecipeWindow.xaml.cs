using CookBook;
using CookbookApp.Models;
using CookBookApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CookbookApp
{
    /// <summary>
    /// Interaction logic for EditRecipeView.xaml
    /// </summary>
    public partial class EditRecipeWindow : Window
    {
        public EditRecipeWindow()
        {
            InitializeComponent();
        }
        public Recipe SelectedRecipe { get; set; }
        public bool isDelete { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uxRecipeGrid.DataContext = SelectedRecipe;
            uxDeleteButton.Visibility = SelectedRecipe.ID != 0 ? Visibility.Visible : Visibility.Hidden;
            isDelete = false;
        }

        private void uxSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (uxTitleError.Text == "")
            {
                isDelete = false;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please fix errors before saving.", "Errors", MessageBoxButton.OK);
            }
        }

        private void uxNewIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(uxNewIngredientPrice.Text, out decimal res))
            {
                Ingredient ingredient = new Ingredient
                {
                    Name = uxNewIngredientName.Text,
                    Price = res,
                    ImageURL = uxNewIngredientURL.Text
                };
                SelectedRecipe.Ingredients.Add(ingredient);
                uxNewIngredientName.Text = "";
                uxNewIngredientPrice.Text = "";
                uxNewIngredientURL.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter a valid price", "invalid price", MessageBoxButton.OK);
                return;
            }
        }

        private void uxDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show($"Are you sure you want to delete {SelectedRecipe.Title}?", "Delete?", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                App.CookBookRepository.Remove(SelectedRecipe.ToRepositoryModel());
                MessageBox.Show($"{SelectedRecipe.Title} has been deleted");
                isDelete = true;
                DialogResult = true;
                Close();
            }
        }

        private void uxCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxIngredientDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (int.TryParse(btn.Tag.ToString(), out int id)) {
                Ingredient ingredient = SelectedRecipe.Ingredients.Where(ing => ing.ID == id).First();
                MessageBoxResult res = MessageBox.Show($"Are you sure you want to delete {ingredient.Name}?", "Delete", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    SelectedRecipe.Ingredients.Remove(ingredient);
                    App.CookBookRepository.RemoveIngredient(ingredient.ID, true);
                }
            }

        }
    }
}
