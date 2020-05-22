using HelloWorld.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for ImgurWindow.xaml
    /// </summary>
    public partial class ImgurWindow : Window
    {
        private HttpClient httpClient = new HttpClient();
        public ImgurWindow()
        {
            InitializeComponent();
            uxTextBox.Text = GetUrl();
        }

        public string GetUrl ()
        {
            httpClient.BaseAddress = new Uri("https://api.imgur.com/");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Client-ID 2280591526449b5");
            HttpResponseMessage res = httpClient.GetAsync("3/gallery/t/kitten").Result;
            string data = res.Content.ReadAsStringAsync().Result;
            ImgurModel imgurModel = JsonConvert.DeserializeObject<ImgurModel>(data);
            return "foo";
        }

        private void uxGetKitten_Click(object sender, RoutedEventArgs e)
        {
            GetUrl();
        }
    }
}
