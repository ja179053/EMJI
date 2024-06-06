using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EMJI.Models;
namespace EMJI.Components.Classes
{
    public class Database
    {
        SQLiteAsyncConnection database;

        public Database()
        {
        }

        async Task Init(DatabaseType type)
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath + type.ToString(), Constants.Flags);
            //var result = await database.CreateTableAsync<TodoItem>();
            Task t = database.CreateTableAsync<Reservation>();
            switch (type)
            {
                case DatabaseType.Reservations:
                    t = database.CreateTableAsync<Reservation>();
                    break;
                case DatabaseType.Clients:
                    t = database.CreateTableAsync<Client>();
                    break;
                default:
                    t = database.CreateTableAsync<TodoItem>();
                    break;
            }
            await t;
        }
        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await Init(DatabaseType.Other);
            return await database.Table<TodoItem>().ToListAsync();
        }
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            await Init(DatabaseType.Reservations);
            return await database.Table<Reservation>().ToListAsync();
        }
        public async Task<List<object>> GetAsync(DatabaseType dt)
        {
            await Init(dt);
            return await database.Table<object>().ToListAsync();
        }
        public async Task<object> AddAsync(DatabaseType dt, object obj)
        {
            await Init(dt);
            switch (dt) {
                case DatabaseType.Other:
                    TodoItem item = (TodoItem)obj;
            if (item.ID != 0)
                return await database.UpdateAsync(item);
            else
                return await database.InsertAsync(item);
                case DatabaseType.Reservations:
                    Reservation reservation = (Reservation)obj;
                    //await AddClient(reservation.ClientInfo);
                    return await database.InsertAsync(reservation);
        }
            return null;
        }
        async Task<object> AddClient(Client client)
        {
            await Init(DatabaseType.Clients);
            //Check phone number and email aren't already existing
            return await database.InsertAsync(client);
        }

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            await Init(DatabaseType.Other);
            return await database.Table<TodoItem>().Where(t => t.Done).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            await Init(DatabaseType.Other);
            return await database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            await Init(DatabaseType.Other);
            if (item.ID != 0)
                return await database.UpdateAsync(item);
            else
                return await database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            await Init(DatabaseType.Other);
            return await database.DeleteAsync(item);
        }
    }
    public enum DatabaseType{
        Reservations,
        Clients,
        Other
    }
}
