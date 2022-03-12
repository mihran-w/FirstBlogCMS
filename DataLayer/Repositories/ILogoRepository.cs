using DataLayer.Models;
using DataLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ILogoRepository : IDisposable
    {
        IEnumerable<Logo> GetAll();
        Logo GetByID(int LogoID);
        int LogoCount();
        LogoViewModel GetByIdForVM(int LogoID);
        bool Create(Logo logo);
        bool Edit(Logo logo);
        bool Delete(int LogoID);
        void Save();
    }
}
