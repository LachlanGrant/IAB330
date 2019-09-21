using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupR.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        Task<IEnumerable<T>> SearchItems(String SearchQuery);
    }
}
