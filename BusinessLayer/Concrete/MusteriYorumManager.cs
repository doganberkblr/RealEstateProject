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
    public class MusteriYorumManager : IMusteriYorumService
    {
        IMusteriYorumDAL _musteriYorumDAL;
        public MusteriYorumManager(IMusteriYorumDAL musteriYorumDAL)
        {
                _musteriYorumDAL = musteriYorumDAL;
        }
        public void Tadd(MusteriYorum t)
        {
            _musteriYorumDAL.Insert(t); 
        }

        public void Tdelete(MusteriYorum t)
        {
           _musteriYorumDAL.Delete(t);
        }

        public MusteriYorum TgetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MusteriYorum> TgetList()
        {
           return _musteriYorumDAL.GetList();
        }

        public void Tupdate(MusteriYorum t)
        {
           _musteriYorumDAL.Update(t);
        }
    }
}
