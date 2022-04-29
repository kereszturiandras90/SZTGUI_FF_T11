using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_FF_T11_Repo
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        public abstract T Load(string path);

        public abstract void Save(T entity, string path);
    }
}
