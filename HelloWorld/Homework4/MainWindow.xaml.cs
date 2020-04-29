using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
        public MainWindow()
        {
            InitializeComponent();
            uxButton.IsEnabled = false;
        }

        private void uxTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if ((Regex.Match(tb.Text, _usZipRegEx).Success) || (Regex.Match(tb.Text, _caZipRegEx).Success))
            {
                uxButton.IsEnabled = true;
            }
            else
            {
                uxButton.IsEnabled = false;
            }
        }

        private void uxButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I'm Enabled!");
        }
    }
}
