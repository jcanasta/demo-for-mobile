using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using OrderingApp.Models.Core.Customer;

namespace OrderingApp.Data
{
    public class CustomerDB
    {
        readonly SQLiteAsyncConnection database;

        public CustomerDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Customer>().Wait();
        }
        public Task<List<Customer>> GetItemsAsync()
        {
            return database.Table<Customer>().ToListAsync();
        }
        public Task<List<Customer>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Customer>("SELECT * FROM [Customer] WHERE [Done] = 0");
        }

        public Task<Customer> GetItemAsync(int id)
        {
            return database.Table<Customer>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<Customer> GetUserInfo(string username , string password)
        {
            return database.Table<Customer>().Where(i => i.UserName == username && i.Password == password).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Customer item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Customer item)
        {
            return database.DeleteAsync(item);
        }
    }
}
