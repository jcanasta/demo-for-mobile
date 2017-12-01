using OrderingApp.Models.Sales.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Data
{
    public class OrderDB
    {
        readonly SQLiteAsyncConnection database;

        public OrderDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Order>().Wait();
        }
        public Task<List<Order>> GetItemsAsync()
        {
            return database.Table<Order>().ToListAsync();
        }
        public Task<List<Order>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Order>("SELECT * FROM [Order] WHERE [IsDone] = 0");
        }
        public Task<Order> MaxOrderID()
        {
            return database.Table<Order>().OrderByDescending(c => c.OrderID).FirstOrDefaultAsync();
        }

        public Task<Order> GetItemAsync(int id)
        {
            return database.Table<Order>().Where(i => i.OrderID == id).FirstOrDefaultAsync();
        }
        public Task<List<Order>> GetItemByCustomerIDAsync(string id)
        {
            return database.Table<Order>().Where(i => i.CustomerID == id).ToListAsync();
        }

        public Task<int> SaveItemAsync(Order item)
        {
            var exist = database.Table<Order>().Where(c => c.OrderID == item.OrderID).FirstOrDefaultAsync().Result;
            if (exist != null)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveAllItem(List<Order> items)
        {
            return database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(Order item)
        {
            return database.DeleteAsync(item);
        }
    }
}
