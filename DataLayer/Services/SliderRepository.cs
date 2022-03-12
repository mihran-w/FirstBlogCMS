using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModel;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class SliderRepository : ISliderRepository
    {
        // Dependency
        private MyBlogContext db;
        public SliderRepository(MyBlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Slider> GetAll()
        {
            var list = db.sliders.ToList();
            return list;
        }

        public Slider GetByID(int SliderID)
        {
            var getId = db.sliders.Find(SliderID);
            return getId;
        }

        public bool Create(Slider slider)
        {
            try
            {
                var AddSlider = db.sliders.Add(slider);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن اسلاید با خطا مواجه شد");
            }
        }

        public bool Edit(Slider slider)
        {
            try
            {
                db.Entry(slider).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش اسلاید با خطا مواجه شد");
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                var getId = GetByID(ID);
                db.sliders.Remove(getId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف اسلاید با خطا مواجه شد");
            }
        }



        public SliderViewModel GetByIdForVM(int SliderID)
        {
            var getid = db.sliders.Where(x => x.SlideID == SliderID).Select(x => new SliderViewModel()
            {
                SlideID = x.SlideID,
                Title = x.Title,
                ImageName = x.ImageName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsActive = x.IsActive,
                Url = x.Url
            }).FirstOrDefault();
            return getid;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}
