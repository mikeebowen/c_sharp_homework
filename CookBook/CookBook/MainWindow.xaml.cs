using CookbookApp;
using CookBookApp.Models;
using CookbookRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private GridViewColumnHeader selectedRow = null;
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
            uxEditRecipe.IsEnabled = false;
        }

        private void uxListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecipe = (Recipe)uxListView.SelectedValue;
            uxView.IsEnabled = selectedRecipe != null ? true : false;
            uxEditRecipe.IsEnabled = selectedRecipe != null ? true : false;
        }

        private void uxView_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow();
            viewRecipeWindow.SelectedRecipe = selectedRecipe;
            viewRecipeWindow.ShowDialog();
        }

        private void uxNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            EditRecipeWindow editRecipeWindow = new EditRecipeWindow();
            editRecipeWindow.SelectedRecipe = new Recipe();
            if (editRecipeWindow.ShowDialog() == true)
            {
                App.CookBookRepository.Add(editRecipeWindow.SelectedRecipe.ToRepositoryModel());
                LoadRecipes();
            }
        }

        private void uxEditRecipe_Click(object sender, RoutedEventArgs e)
        {
            EditRecipeWindow editRecipeWindow = new EditRecipeWindow();
            editRecipeWindow.SelectedRecipe = selectedRecipe;
            if (editRecipeWindow.ShowDialog() == true)
            {
                if (editRecipeWindow.isDelete == false)
                {
                    App.CookBookRepository.Update(selectedRecipe.ToRepositoryModel());
                }
                LoadRecipes();
            }
        }

        private void uxNameHeader_Click(object sender, RoutedEventArgs e)
        {
            sortRows(sender);
        }

        private void uxAuthorHeader_Click(object sender, RoutedEventArgs e)
        {
            sortRows(sender);
        }
        private void sortRows(object sender)
        {
            GridViewColumnHeader header = (sender as GridViewColumnHeader);
            string sortBy = header.Tag.ToString();
            ListSortDirection newDir = selectedRow == header && uxListView.Items.SortDescriptions.LastOrDefault().Direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            selectedRow = header;
            uxListView.Items.SortDescriptions.Clear();
            uxListView.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }
    }
}
