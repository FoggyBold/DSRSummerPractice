using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_Summer_Practice.Shared.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> find(DateTime start, DateTime end);
        T get();
    }
}
