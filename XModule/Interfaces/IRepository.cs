using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;

namespace XModule.Interfaces
{
    public interface IRepository<T> where T: IEntity 
    { 
        EntityApi Api { get; }
    
        /// <summary>
        /// Adds an item to the repository
        /// </summary>
        /// <param name="item"></param>
        void Add(T entity);

        /// <summary>
        /// Retrievces all entities 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Searches for an entity
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Find(int key);

        /// <summary>
        /// Removes an entity based on a key
        /// </summary>
        /// <param name="key"></param>
        void Remove(int key);

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="item"></param>
        void Update(T entity);
    }
}
