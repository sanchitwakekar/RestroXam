﻿using SQLite;
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
        //------------------------------Owner Methods---------------------
        public static ObservableCollection<Restaurant> GetRestaurantList(DBHelper db, User user)
        {
            return new ObservableCollection<Restaurant>(db.GetConnection().Table<Restaurant>()
           .Where(x => x.owner_id == user.user_id));
        }
        public static void AddRestaurant(DBHelper _db, Restaurant restaurant)
        {
            SQLiteConnection db = _db.GetConnection();
            db.Insert(restaurant);
            db.Close();
        }
        public static void DeleteRestaurant(DBHelper _db, Restaurant restaurant)
        {
            SQLiteConnection db = _db.GetConnection();
            db.Delete(restaurant);
            db.Close();
        }
        public static void UpdateRestaurant(DBHelper _db, Restaurant restaurant)
        {
            SQLiteConnection db = _db.GetConnection();
            var updateRestaurant = db.Query<Restaurant>($"SELECT * FROM Restaurant WHERE rest_id = '{restaurant.rest_id}'");

            if (db.Update(updateRestaurant) > 0)
            {
                System.Diagnostics.Debug.WriteLine("UPDATED");
            }
            db.Close();
        }
        //-----------------------------------------------------
        public static void AddCategory(DBHelper _db, Category category)
        {
            SQLiteConnection db = _db.GetConnection();
            db.Insert(category);
            db.Close();
        }
        public static ObservableCollection<Category> GetCategoryList(DBHelper db, int rest_id)
        {
            return new ObservableCollection<Category>(db.GetConnection().Table<Category>()
           .Where(x => x.rest_id == rest_id));
        }
        //------------------------------Item---------------------
        public static void AddItem(DBHelper _db, Item item)
        {
            SQLiteConnection db = _db.GetConnection();
            db.Insert(item);
            db.Close();
        }
        //------------------------------User Methods---------------------
        public static ObservableCollection<Restaurant> GetCustomerRestaurantList(DBHelper db)
        {
            return new ObservableCollection<Restaurant>(db.GetConnection().Table<Restaurant>());           
        }
        public static ObservableCollection<Item> GetItemList(DBHelper db, int cat_id)
        {
            return new ObservableCollection<Item>(db.GetConnection().Table<Item>()
           .Where(x => x.cat_id == cat_id));
        }
        public static ObservableCollection<Item> GetUserRestaurantItemList(DBHelper db, int rest_id)
        {
            return new ObservableCollection<Item>(db.GetConnection().Table<Item>()
           .Where(x => x.rest_id == rest_id));
        }

    }
}
