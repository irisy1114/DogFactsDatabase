using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogFactsDatabase.Models;
using SQLite;

namespace DogFactsDatabase.Data
{
   public class PersonalFactDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PersonalFactDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(PersonalFact).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(PersonalFact)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<PersonalFact>> GetItemsAsync()
        {
            return Database.Table<PersonalFact>().ToListAsync();
        }

        public Task<PersonalFact> GetItemAsync(int id)
        {
            return Database.Table<PersonalFact>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PersonalFact item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> InsertList(IEnumerable<PersonalFact> items)
        {
            return Database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(PersonalFact item)
        {
            return Database.DeleteAsync(item);
        }
        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<PersonalFact>();
        }
    }
}
