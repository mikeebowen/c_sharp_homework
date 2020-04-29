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
using Homework2.Models;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users;
        private GridViewColumnHeader listViewSortCol = null;
        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = (sender as GridViewColumnHeader);
            string sortBy = header.Tag.ToString();
            ListSortDirection newDir = listViewSortCol == header && uxList.Items.SortDescriptions.LastOrDefault().Direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            listViewSortCol = header;
            uxList.Items.SortDescriptions.Clear();
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }
    }
}
