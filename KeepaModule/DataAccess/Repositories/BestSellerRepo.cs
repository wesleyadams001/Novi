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
    /// <summary>
    /// The best sellers repository
    /// </summary>
    public class BestSellerRepo : IRepository<best_sellers>
    {

        KeepaContext _context = null;

        public BestSellerRepo(KeepaContext context)
        {
            _context = context;
        }

        public Enums.EntityApi Api => Enums.EntityApi.Keepa;

        /// <summary>
        /// Add an entity to the database
        /// </summary>
        /// <param name="entity"></param>
        public void Add(best_sellers entity)
        {
            this._context.best_sellers.Add(entity);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Find best sellers via int Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public best_sellers Find(int key)
        {
            var result = (from r in _context.best_sellers where r.Primary_key == key select r).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Get all the records from the best sellers table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<best_sellers> GetAll()
        {
            var result = (from r in _context.best_sellers select r).ToList();

            return result;
        }

        /// <summary>
        /// Remove a particular item based on key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(int key)
        {
            var result = (from r in _context.best_sellers where r.Primary_key == key select r).FirstOrDefault();

            _context.best_sellers.Remove(result);

        }

        /// <summary>
        /// Update a particular record based on entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(best_sellers entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
