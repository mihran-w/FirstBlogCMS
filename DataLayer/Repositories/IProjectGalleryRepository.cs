using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IProjectGalleryRepository : IDisposable
    {
        
        IEnumerable<ProjectGallery> GetAll();
        ProjectGallery GetById(int pGalleryid);
        IEnumerable<ProjectGallery> getArchiveGallery(int id = 1);
        int CountGallery();
        ProjectGalleryViewModel getByVM(int pGalleryid);
        bool Create(ProjectGallery projectGallery);
        bool Edit(ProjectGallery projectGallery);
        bool Delete(int pGalleryid);
        void Save();


    }
}
