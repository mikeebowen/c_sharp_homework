using CookbookApp.Models;
using CookBookApp.Models;
using System;
using System.Collections.Generic;
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
            //ShowInTaskbar = false;
        }
        public Recipe SelectedRecipe { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uxRecipeGrid.DataContext = SelectedRecipe;
        }

        private void uxSaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
