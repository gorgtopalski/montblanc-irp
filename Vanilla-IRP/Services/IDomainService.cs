using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla_IRP.Domain;

namespace Vanilla_IRP.Services
{
    interface IDomainService<T> where T : IDomain
    {
        void Save(T item);

        void Delete(T item);

        List<T> GetAll();
    }
}
