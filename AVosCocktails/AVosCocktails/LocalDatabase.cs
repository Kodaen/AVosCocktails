using System.Collections.Generic;
using System.Threading.Tasks;
using AVosCocktails.Model;
using SQLite;


namespace AVosCocktails
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LocalCocktail>().Wait();
        }

        public Task<List<LocalCocktail>> GetCocktailAsync()
        {
            return _database.Table<LocalCocktail>().ToListAsync();
        }

        public Task<int> SaveCocktailAsync(LocalCocktail LCocktail)
        {
            return _database.InsertAsync(LCocktail);
        }

        public Task<int> DeleteAllCocktails()
        {
            return _database.DeleteAllAsync<LocalCocktail>();
        }

    }
}
