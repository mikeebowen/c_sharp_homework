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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for NumberControl.xaml
    /// </summary>
    public partial class NumberControl : UserControl
    {
        public NumberControl()
        {
            InitializeComponent();
        }

        public int Value { get { return int.Parse(uxTextBox.Text); } }

        private void uxTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key < Key.D0 || e.Key > Key.D9;
        }
    }
}
