using OrderingApp.Models.Sales.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Data
{
    public class OrderDetailDB
    {
        readonly SQLiteAsyncConnection database;

        public OrderDetailDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<OrderDetail>().Wait();
        }
        public Task<List<OrderDetail>> GetItemsAsync()
        {
            return database.Table<OrderDetail>().ToListAsync();
        }
        public Task<List<OrderDetail>> GetItemsNotCancelledAsync()
        {
            return database.QueryAsync<OrderDetail>("SELECT * FROM [OrderDetail] WHERE [IsCancelled] = 0");
        }
        public Task<OrderDetail> MaxOrderID()
        {
            return database.Table<OrderDetail>().OrderByDescending(c => c.OrderID).FirstOrDefaultAsync();
        }

        public Task<OrderDetail> GetItemAsync(int id)
        {
            return database.Table<OrderDetail>().Where(i => i.OrderID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(OrderDetail item)
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
        public Task<int> SaveAllItem(List<OrderDetail> items)
        {
            return database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(OrderDetail item)
        {
            return database.DeleteAsync(item);
        }
    }
}
