using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MusteriMesajManager : IMusteriMesajService
    {
        IMusteriMesajDAL _musteriMesajDAL;
        public MusteriMesajManager(IMusteriMesajDAL musteriMesajDAL)
        {
                _musteriMesajDAL = musteriMesajDAL;
        }
        public void Tadd(MusteriMesaj t)
        {
            _musteriMesajDAL.Insert(t);
        }

        public void Tdelete(MusteriMesaj t)
        {
            _musteriMesajDAL.Delete(t);
        }

        public MusteriMesaj TgetByID(int id)
        {
            return _musteriMesajDAL.Get(id);
        }

        public MusteriMesaj MusteriMesajGetir(MusteriMesaj t)
        {
            return _musteriMesajDAL.Getir(t);
        }

        public List<MusteriMesaj> TgetList()
        {
           return _musteriMesajDAL.GetList();
        }

        public void Tupdate(MusteriMesaj t)
        {
           _musteriMesajDAL.Update(t);  
        }
    }
}
