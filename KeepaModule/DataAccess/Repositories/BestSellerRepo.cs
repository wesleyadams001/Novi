using KeepaModule.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Constants;
using XModule.Interfaces;

namespace KeepaModule.DataAccess.Repositories
{
    //public class BestSellerRepo : IRepository<best_sellers>
    //{

    //    KeepaContext _context;

    //    public Enums.EntityApi Api => Enums.EntityApi.Keepa;

    //    public void Add(best_sellers entity)
    //    {
    //        this._context.best_sellers.Add(entity);

    //        this._context.SaveChanges();
    //    }

    //    public best_sellers Find(int key)
    //    {
    //        var result = (from r in _context.best_sellers where r.primary_key == key select r).FirstOrDefault();

    //        return result;
    //    }

    //    public IEnumerable<best_sellers> GetAll()
    //    {
    //        var result = (from r in _context.best_sellers select r).ToList();

    //        return result;
    //    }

    //    public void Remove(int key)
    //    {
    //        var result = (from r in _context.best_sellers where r.primary_key == key select r).FirstOrDefault();
          
    //        _context.best_sellers.Remove(result);
            
    //    }

    //    public void Update(best_sellers entity)
    //    {
    //        _context.Entry(entity).State = EntityState.Modified;

    //        _context.SaveChanges();
    //    }
    //}
}
