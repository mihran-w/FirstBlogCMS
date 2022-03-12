using DataLayer.Models;
using DataLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBlogRepository : IDisposable
    {
        IEnumerable<Blog> GetAll();
        IEnumerable<Blog> Search(string Param);
        IEnumerable<Blog> GetLastBlog(int take = 3);
        IEnumerable<Blog> ArchiveBlog(int id = 1);
        int CountBlog();
        Blog GetByID(int BlogId);
        BlogViewModel GetByIdForVM(int BlogId);
        bool Create(Blog blog);
        bool Edit(Blog blog);
        bool Delete(int BlogID);
        void Save();
    }
}
