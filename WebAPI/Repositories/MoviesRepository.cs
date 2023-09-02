using Model.Models;
using ModelContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Repositories
{
    public class MoviesRepository
    {
        DBCtx context = new DBCtx();
        public MoviesRepository(DBCtx ctx)
        {
            this.context = ctx;
        }
        public IEnumerable<Movies> GetList()
        {
            IEnumerable<Movies> Datas = context.movies;
            return Datas;
        }
        public void Insert(Movies data)
        {
            context.movies.Add(data);
            context.SaveChanges();
        }
        public void Update(Movies Data)
        {
            var entry = context.Entry<Movies>(Data);

            if (entry.State == EntityState.Detached)
            {
                var set = context.Set<Movies>();
                Movies attachedEntity = set.Local.SingleOrDefault(e => e.id == Data.id); 

                if (attachedEntity != null)
                {
                    var attachedEntry = context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(Data);
                }
                else
                {
                    entry.State = EntityState.Modified; 
                }
            }
            context.SaveChanges();
        }
        public void Delete(Movies data)
        {
            context.movies.Remove(data);
            context.SaveChanges();
        }
    }
}