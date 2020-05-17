using System;
using System.Collections.Generic;
using System.Text;
using CookBookDB;

namespace CookBookRepository
{
    class DatabaseManager
    {
        private static readonly RecipesContext entities;
        static DatabaseManager()
        {
            entities = new RecipesContext();
        }

        public static RecipesContext Instance
        {
            get { return entities; }
        }
    }
}
