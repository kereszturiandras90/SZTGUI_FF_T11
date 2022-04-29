using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_FF_T11_Repo
{
    public interface IRepository<T>
        where T : class
    {
        void Save(T entity, string path);

        T Load(string path);
    }
}
