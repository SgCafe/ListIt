using ListIt.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListIt.Repository
{
    class SQLiteRepository<T> : IDataRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection _connection;
        public SQLiteRepository()
        {
            string dbPath = DependencyService.Get<IDbPathProvider>().GetDatabasePath();
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<T>().Wait();
        }

        public Task<int> DeleteAsync(T item)
        {
            return _connection.DeleteAsync(item);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _connection.Table<T>().ToListAsync();
        }

        public Task<int> InsetAsync(T item)
        {
            return _connection.InsertAsync(item);
        }

        public Task<int> UpdateAsync(T item)
        {
            return _connection.UpdateAsync(item);
        }
    }
}
