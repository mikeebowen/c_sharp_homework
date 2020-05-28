using System;
using System.Collections.Generic;
using System.Text;
using CookbookDB;

namespace CookbookRepository
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
