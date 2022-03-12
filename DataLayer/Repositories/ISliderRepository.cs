using DataLayer.Models;
using DataLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ISliderRepository : IDisposable
    {
        IEnumerable<Slider> GetAll();
        Slider GetByID(int SliderID);

        // For View Model
        SliderViewModel GetByIdForVM(int SliderID);
        
        bool Create(Slider slider);
        bool Edit(Slider slider);
        bool Delete(int ID);
        void Save();
    }
}
