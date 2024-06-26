﻿using EMJI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Components.Classes
{
    public static class Constants
    {
        public static User thisUser;
        public static bool hasAdminAccess { get => thisUser != null && thisUser.permissions == UserAccess.Admin; }
        public static bool hasStaffAccess { get => thisUser != null && thisUser.permissions != UserAccess.Client; }
        public const string DatabaseFilename = "DatabaseSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        public static DateTime Tomorrow = DateTime.Today.AddDays(1);

        public static List<FoodItem> menu;
        public static List<Order> orders;

        public static Reservation testReservation = new Reservation { Date = Tomorrow, Notes = "None", Size = 2, ClientInfo = new Client { FirstName = "Bill", Surname = "Will", ID = Guid.NewGuid(), Email = "test@gmail.com", PhoneNumber = "07777777777" } };
        public static Reservation newReservation = new Reservation { Date = Tomorrow, Notes = "None", Size = 2, ClientInfo = new Client { FirstName = "", Surname = "", ID = Guid.NewGuid(), Email = "", PhoneNumber = "" } };

        public static FoodItem testFoodItem = new FoodItem { Name = "Bread", Price = 3.00M, Quantity=1, Status = FoodStatus.Ordered };
        public static Order testOrder { get => new Order { orders = new List<FoodItem> { testFoodItem } }; }
        /// <summary>
        /// The maximum number of minutes a customer should have to wait for their order
        /// </summary>
        public static int MaxWaitTime = 15;

        public static Table testTable = new Table { Name = "Table 1", Id = 1, Notes = "Gluten Allergy", Status = TableStatus.Seated, Order = new List<Order> { testOrder}, Reservation = testReservation, LastUpdated = DateTime.Now };

        public static Color Green = new Color(0, 255, 0);
        public static Color Red = new Color(255, 0, 0);
        public static Color Blue = new Color(0, 0, 255);
        public static Color White = new Color(255, 255, 255);
        public static Color Purple = new Color(255, 0, 255);
        public static Color Yellow = new Color(255, 255, 0);
        public static Color Cyan = new Color(0, 255, 255);
        public static Color LightGreen = new Color(0, 255, 125);
    }
}
