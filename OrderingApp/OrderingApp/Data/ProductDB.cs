using OrderingApp.Models.Sales;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Data
{
    public class ProductDB
    {
        readonly SQLiteAsyncConnection database;

        public ProductDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product>().Wait();
        }
        public Task<List<Product>> GetItemsAsync()
        {
            return database.Table<Product>().ToListAsync();
        }
        public Task<List<Product>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Done] = 0");
        }

        public Task<Product> GetItemAsync(int id)
        {
            return database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Product item)
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
        public Task<int> SaveAllItem(List<Product> items)
        {
            return database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(Product item)
        {
            return database.DeleteAsync(item);
        }
    }
}
