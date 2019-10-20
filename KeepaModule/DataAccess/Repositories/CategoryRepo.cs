using KeepaModule.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Constants;
using XModule.Interfaces;

namespace KeepaModule.DataAccess.Repositories
{
    public class CategoryRepo : IRepository<category>
    {
        public Enums.EntityApi Api => throw new NotImplementedException();

        public void Add(category entity)
        {
            throw new NotImplementedException();
        }

        public category Find(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(category entity)
        {
            throw new NotImplementedException();
        }
    }
}
