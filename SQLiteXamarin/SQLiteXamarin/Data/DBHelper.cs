using SQLite;
using SQLiteXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace SQLiteXamarin.Data
{
    class DBHelper : ISQLite
    {
        SQLiteConnection conn;
        public SQLiteConnection GetConnection()
        {
            conn = new SQLiteConnection(App.DatabasePath);
            return conn;
        }
        public void SetupTables()
        {
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RestroXam.db");
            var db = new SQLiteConnection(App.DatabasePath);
            db.CreateTable<User>();
            db.CreateTable<Restaurant>();
            db.CreateTable<Category>();
            db.CreateTable<Item>();
        }
        public static void AddUser(DBHelper _db, User user)
        {
            SQLiteConnection db = _db.GetConnection();
            db.Insert(user);
            db.Close();
        }
        public static User GetUser(DBHelper db, User user)
        {
            return db.GetConnection().Table<User>()
           .Where(x => x.username == user.username && x.password == user.password && x.role == user.role)
           .FirstOrDefault();
        }
        public static ObservableCollection<Restaurant> GetRestaurantList(DBHelper db, User user)
        {
            return new ObservableCollection<Restaurant>(db.GetConnection().Table<Restaurant>()
           .Where(x => x.owner_id == user.user_id));
        }

    }
}
