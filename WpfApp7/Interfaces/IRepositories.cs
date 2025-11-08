using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.Interfaces
{
     public interface IReposotory<T>
    {
        public T? Get(int id);
        IEnumerable<T>? GetAll();
        public bool Add(T entity);
        public bool Remove (int id);
        public bool Update(int id, T entity);
    }

}
