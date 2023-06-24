using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDAL _kullaniciDAL;
        private IWebHostEnvironment webHostEnvironment;

        public KullaniciManager(IKullaniciDAL kullaniciDAL)
        {
                _kullaniciDAL = kullaniciDAL;
        }

        public KullaniciManager(IKullaniciDAL kullaniciDAL, IWebHostEnvironment webHostEnvironment) : this(kullaniciDAL)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void Tadd(Kullanici t)
        {
            _kullaniciDAL.Insert(t);
        }

        public void Tdelete(Kullanici t)
        {
            _kullaniciDAL.Delete(t);
        }

        public Kullanici TgetByID(int id)
        {
            return _kullaniciDAL.Get(id);
        }
        public Kullanici kullaniciGetir(Kullanici t)
        {
            return _kullaniciDAL.Getir(t);
        }
        public List<Kullanici> TgetList()
        {
            return _kullaniciDAL.GetList();
        }

        public void Tupdate(Kullanici t)
        {
            _kullaniciDAL.Update(t);
        }
    }
}
