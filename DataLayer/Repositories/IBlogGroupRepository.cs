using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBlogGroupRepository : IDisposable
    {
        IEnumerable<BlogGroup> GetAll();
        BlogGroup GetByID(int GroupID);

        bool Create(BlogGroup blogGroup);
        bool Edit(BlogGroup blogGroup);
        bool DeleteByID(int GroupID);
        void Save();
    }
}
