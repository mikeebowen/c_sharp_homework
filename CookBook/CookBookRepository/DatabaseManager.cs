using System;
using System.Collections.Generic;
using System.Text;
using CookbookDB;

namespace CookBookRepository
{
    class DatabaseManager
    {
        private static readonly CookbookContext entities;
        static DatabaseManager()
        {
            entities = new CookbookContext();
        }

        public static CookbookContext Instance
        {
            get { return entities; }
        }
    }
}
