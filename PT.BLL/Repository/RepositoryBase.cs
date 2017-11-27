using PT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.Repository
{
    public class RepositoryBase<T, TId> where T : class
    {
        //dosya işlemlerinde,veritabanı işlemlerinde , kullanıcıdan bişey istendiğinde 
        protected internal MyContext dbContext;// başka yerden erişebilmemesi için 

        public virtual List<T> GetAll()
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                return dbContext.Set<T>().ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public virtual T GetById(TId id)
        {
            dbContext = new MyContext();
            return dbContext.Set<T>().Find(id);


        }


        public virtual int Insert(T entity)
        {

            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual int Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual int Update()
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                return dbContext.SaveChanges();


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}
