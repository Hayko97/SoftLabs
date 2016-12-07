using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.Interfaces
{
    interface IHelper<T>
    {
        Task AddItem(T model);

        Task<List<T>> GetAllItems();

        Task DeleteItem(string id);
    }
}
