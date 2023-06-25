using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HizmetManager : IHizmetService
    {
        IHizmetDAL _hizmetDAL;
        public HizmetManager(IHizmetDAL hizmetDAL)
        {
            _hizmetDAL = hizmetDAL;  
        }

        public void Tadd(Hizmetler t)
        {
            _hizmetDAL.Insert(t);
        }

        public void Tdelete(Hizmetler t)
        {
            _hizmetDAL.Delete(t);
        }

        public Hizmetler TgetByID(int id)
        {
            return _hizmetDAL.Get(id);
        }

        public Hizmetler HizmetGetir(Hizmetler t)
        {
            return _hizmetDAL.Getir(t);
        }

        public List<Hizmetler> TgetList()
        {
            return _hizmetDAL.GetList();

        }

        public void Tupdate(Hizmetler t)
        {
            _hizmetDAL.Update(t);
        }
    }
}
