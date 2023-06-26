using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        Context db = new Context();
        public void Delete(T t)
        {
            db.Remove(t);
            db.SaveChanges();
        }

		public T Get(int id)
		{
            return db.Set<T>().Find(id);
		}

        public T Getir(T t)
        {
            return db.Set<T>().Find(t);
        }

        public List<T> Getir(Expression<Func<T, bool>> filtre)
        {
            return db.Set<T>().Where(filtre).ToList();
        }

        public List<T> GetList()
        { 
           
            return db.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            db.Add(t);
            db.SaveChanges();
        }

        public void Update(T t)
        {
            db.Update(t);
            db.SaveChanges() ;
        }
    }

}
