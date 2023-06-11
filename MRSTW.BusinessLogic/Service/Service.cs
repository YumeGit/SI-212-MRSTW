using MRSTW.BusinessLogic.Database;
using MRSTW.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace MRSTW.BusinessLogic.Service
{
    public class Service : IDisposable
    {
        internal static BlogDbContext DbContext = new BlogDbContext();

        public static ServiceResponse<T> Success<T>(T entry = default)
        {
            return new ServiceResponse<T>
            {
                Success = true,
                Entry = entry
            };
        }

        public static ServiceResponse<T> Failure<T>(string message)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message,
            };
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Entry { get; set; }
    }

    public class ModelService<TModel> : Service where TModel : class
    {
        public ServiceResponse<TModel> Get(int id)
        {
            return Success(DbContext.Set<TModel>().Find(id));
        }

        public ServiceResponse<TModel[]> GetAll()
        {
            return Success(DbContext.Set<TModel>().ToArray());
        }

        public ServiceResponse<TModel> Find(Func<TModel, bool> predicate)
        {
            return Success(DbContext.Set<TModel>().FirstOrDefault(predicate));
        }

        public ServiceResponse<TModel[]> FindAll(Func<TModel, bool> predicate)
        {
            return Success(DbContext.Set<TModel>().Where(predicate).ToArray());
        }

        public ServiceResponse<TModel> Attach(TModel model)
        {
            DbContext.Set<TModel>().Attach(model);
            return Success(model);
        }

        public ServiceResponse<TModel> Add(TModel model)
        {
            return ChangeState(model, EntityState.Added);
        }

        public ServiceResponse<TModel> AddOrUpdate(TModel model)
        {
            DbContext.Set<TModel>().AddOrUpdate(model);
            return Success(model);
        }

        public ServiceResponse<TModel> Delete(TModel model)
        {
            return ChangeState(model, EntityState.Deleted);
        }

        public ServiceResponse<TModel> Edit(TModel model)
        {
            return ChangeState(model, EntityState.Modified);
        }

        public ServiceResponse<TModel> ChangeState(TModel model, EntityState state)
        {
            DbContext.Entry(model).State = state;
            DbContext.SaveChanges();
            return Success(model);
        }

        public void LoadReference(TModel model, string navigationProperty)
        {
            DbContext.Set<TModel>().Attach(model);
            DbContext.Entry(model).Reference(navigationProperty).Load();
        }

        public void LoadReference<U>(TModel model, Expression<Func<TModel, U>> predicate) where U : class
        {
            DbContext.Set<TModel>().Attach(model);
            DbContext.Entry(model).Reference(predicate).Load();
        }

        public void LoadCollection(TModel model, string navigationProperty)
        {
            DbContext.Set<TModel>().Attach(model);
            DbContext.Entry(model).Collection(navigationProperty).Load();
        }

        public void LoadCollection<U>(TModel model, Expression<Func<TModel, ICollection<U>>> predicate) where U : class
        {
            DbContext.Set<TModel>().Attach(model);
            DbContext.Entry(model).Collection(predicate).Load();
        }
    }
}