using System;
using System.Data.SQLite;
using System.IO;
using BeerOrder;

namespace BeerOrder
{
    public class Database
    {
        private readonly string _dbPath;

        public Database(string dbPath)
        {
            _dbPath = dbPath;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            
        }
        

        public int SaveOrder(Models.BeerOrder Zamowienia)
        {
            try
            {
                using var connection = new SQLiteConnection($"Data Source=BeerOrder.db;Version=3;");
                connection.Open();
                string insertQuery  = @"
                    INSERT INTO Zamowienia (name, surname, street, city, postalcode, phone)
                    VALUES (@Name, @Surname, @Street, @City, @PostalCode, @Phone)";
                using var command = new SQLiteCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Name", Zamowienia.name);
                command.Parameters.AddWithValue("@Surname", Zamowienia.surname);
                command.Parameters.AddWithValue("@Street", Zamowienia.street);
                command.Parameters.AddWithValue("@City", Zamowienia.city);
                command.Parameters.AddWithValue("@PostalCode", Zamowienia.postalcode);
                command.Parameters.AddWithValue("@Phone", Zamowienia.phone);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Insert error: {ex.Message}");
                return -1;
            }
        }
    }
}
