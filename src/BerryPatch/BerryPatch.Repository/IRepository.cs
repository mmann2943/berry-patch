using System;
using System.Collections.Generic;

namespace BerryPatch.Repository
{
    public interface IRepository<T>
    {
        List<T> Find(Func<T, bool> query);
    }
}