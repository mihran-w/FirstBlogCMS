using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBlogCommentRepository : IDisposable
    {
        IEnumerable<BlogComment> GetAll();
        IEnumerable<BlogComment> GetCommentByBlogId(int blogId);
        BlogComment GetByID(int CommentID);
        bool Create(BlogComment blogComment);
        bool DeleteById(int BlogCommentID);
        void Save();

    }
}
