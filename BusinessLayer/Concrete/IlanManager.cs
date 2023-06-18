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
    public class IlanManager : IIlanService
    {
        IIlanDAL _IlanDAL;
        public IlanManager(IIlanDAL ilanDAL)
        {
            _IlanDAL = ilanDAL;
        }
        public void Tadd(Ilan t)
        {
            _IlanDAL.Insert(t);
        }

        public void Tdelete(Ilan t)
        {
            _IlanDAL.Delete(t);
        }

        public Ilan TgetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ilan> TgetList()
        {
            return _IlanDAL.GetList();
        }

        public void Tupdate(Ilan t)
        {
            _IlanDAL.Update(t);
        }
    }
}
