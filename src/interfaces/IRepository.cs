using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.src;

    public interface IRepository<T>
    {
        List<T> ListAll();
        T getById(int id);
        void Insert(T serie);
        void Delete(int id);
        void Update(int id, T serie);
        int NextId();
    }
