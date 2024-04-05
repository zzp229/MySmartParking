using Microsoft.EntityFrameworkCore;
using SmarkParking.Server.IService;
using SmartParking.Server.IEFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmarkParking.Server.Service
{
    public class ServiceBase : IServiceBase
    {

        protected DbContext Context { get; private set; }
        public ServiceBase(IEFContext eFContext)
        {
            Context = eFContext.CreateDBContext();
        }

        public void Commit()
        {
            this.Context.SaveChanges(); // 直接保存就行了
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);
            if (t == null) throw new Exception("t is null");    // 如果是空就报错
            this.Context.Set<T>().Remove(t);    // 删除这个
            this.Commit();  // 删完提交
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");    // 如果是空就报错
            this.Context.Set<T>().Attach(t);    // 尊卑删除这个实体
            this.Context.Set<T>().Remove(t);    // 删除这个
            this.Commit();  // 删完提交
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            // 将要删除的实体标记上
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);    // 要删除这个实体
            }
            this.Context.Set<T>().RemoveRange(tList);    // 删除这个集合
            this.Commit();  // 删完提交
        }

        public T Find<T>(int id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);   // 添加
            this.Commit();  // 提交
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.Context.Set<T>().AddRange(tList);
            this.Commit();  //
            return tList;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this.Context.Set<T>().Where<T>(funcWhere);
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");

            this.Context.Set<T>().Attach(t);    // 跟踪实体
            this.Context.Entry<T>(t).State = EntityState.Modified;  // 标记为已修改
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            // 跟踪和标记更改
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        public virtual void Dispose()
        {
            if (this.Context != null)
                this.Context.Dispose();
        }
    }
}
