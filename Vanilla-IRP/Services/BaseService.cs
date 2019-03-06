using System;
using System.Collections.Generic;
using System.Windows;
using LiteDB;
using MvvmFoundation.Wpf;
using Vanilla_IRP.Database;
using Vanilla_IRP.Domain;

namespace Vanilla_IRP.Services
{
    public class BaseService<T> : ObservableObject, IDomainService<T> where T : IDomain
    {
        public List<T> Values => GetAll();

        protected readonly LiteRepository Db;

        public BaseService()
        {
            Db = CommonsDb.Db();
        }

        public void Save(T item)
        {
            Db.Upsert(item);
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
