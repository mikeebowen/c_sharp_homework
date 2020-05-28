using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CookBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static CookbookRepository.CookBookRepository cookBookRepository;

        static App()
        {
            cookBookRepository = new CookbookRepository.CookBookRepository();
        }
        public static CookbookRepository.CookBookRepository CookBookRepository { get { return cookBookRepository; } }
    }
}
