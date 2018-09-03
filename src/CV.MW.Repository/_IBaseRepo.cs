using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.Repository
{
    public interface _IBaseRepo<T>
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
}
