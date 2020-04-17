using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.EntityFrameworkCore;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            uxContainer.DataContext = user;
            SampleContext sample = new SampleContext();
            sample.User.Load();
            ObservableCollection<User> users = sample.User.Local.ToObservableCollection();
            uxList.ItemsSource = users;
            //WindowState = WindowState.Maximized;
            uxSubmit.IsEnabled = false;
            uxContainer.DataContext = user;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Submitting password: {uxPassword.Text}");
            SecondWindow sw = new SecondWindow();
            Application.Current.MainWindow = sw;
            Close();
            sw.Show();
        }

        private void uxThumbsUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckSubmitStatus()
        {
            if (uxName.Text != "" && uxPassword.Text != "")
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSubmitStatus();
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSubmitStatus();
        }
    }
}
