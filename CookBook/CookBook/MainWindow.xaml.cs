using CookbookApp;
using CookBookApp.Models;
using CookbookRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Recipe selectedRecipe;
        public MainWindow()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            List<CookbookRepositoryRecipe> recipes = App.CookBookRepository.GetAll();
            var rs = recipes
                .Select(r => Recipe.ToModel(r))
                .ToList();
            uxListView.ItemsSource = rs;
            uxView.IsEnabled = false;
        }

        private void uxListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecipe = (Recipe)uxListView.SelectedValue;
            uxView.IsEnabled = selectedRecipe != null ? true : false;
        }

        private void uxView_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow();
            viewRecipeWindow.SelectedRecipe = selectedRecipe;
            if (viewRecipeWindow.ShowDialog() == true)
            {

            }
        }
    }
}
