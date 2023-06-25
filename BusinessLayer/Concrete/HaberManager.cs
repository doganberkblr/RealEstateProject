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
    public class HaberManager : IHaberService
    {
        IHaberDAL _haberDAL;
        public HaberManager(IHaberDAL haberDAL)
        {
            _haberDAL = haberDAL;  
        }

        public void Tadd(Haber t)
        {
            _haberDAL.Insert(t);
        }

        public void Tdelete(Haber t)
        {
            _haberDAL.Delete(t);
        }

        public Haber TgetByID(int id)
        {
            return _haberDAL.Get(id);
        }
        public Haber haberGetir(Haber t)
        {
            return _haberDAL.Getir(t);
        }
        public List<Haber> TgetList()
        {
            return _haberDAL.GetList();

        }

        public void Tupdate(Haber t)
        {
            _haberDAL.Update(t);
        }
    }
}
