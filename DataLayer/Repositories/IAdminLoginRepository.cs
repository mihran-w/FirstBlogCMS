using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IAdminLoginRepository : IDisposable
    {
        IEnumerable<AdminLogins> GetAll();
        AdminLogins GetById(int loginId);
        bool Create(AdminLogins login);
        bool Edit(AdminLogins login);
        bool DeleteById(int loginId);
        void Save();
        bool IsExistUser(string username, string password);
    }
}
