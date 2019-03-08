using IRP.Database;
using IRP.Domain;
using LiteDB;
using MvvmFoundation.Wpf;
using System.Collections.Generic;

namespace IRP.Services
{
    public class BaseService<T> : ObservableObject, IDomainService<T> where T : IDomain
    {
        public List<T> Values => GetAll();

        protected readonly LiteRepository Db;

        public BaseService()
        {
            Db = CommonsDb.Db();
        }

        public BaseService(LiteRepository db)
        {
            Db = db;
        }

        public void Save(T item)
        {
            if (item == null) return;
            if (!item.Validate()) return;
            if (item.Id() == BsonValue.Null)
                Db.Insert(item);
            else
                Db.Update(item);

            RaisePropertyChanged(nameof(Values));
        }

        public void Delete(T item)
        {
            if (Db.Delete<T>(item.Id()))
                RaisePropertyChanged(nameof(Values));
        }

        public virtual List<T> GetAll() => Db.Query<T>().ToList();
    }
}
