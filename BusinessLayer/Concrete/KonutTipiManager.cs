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
    public class KonutTipiManager : IKonutTipiService
    {
        IKonutTipiDAL _konutTipiDAL;
        public KonutTipiManager(IKonutTipiDAL konutTipiDAL)
        {
            _konutTipiDAL = konutTipiDAL;
        }
        public void Tadd(KonutTipi t)
        {
            _konutTipiDAL.Insert(t);
        }

        public void Tdelete(KonutTipi t)
        {
            _konutTipiDAL.Delete(t);
        }

        public KonutTipi TgetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<KonutTipi> TgetList()
        {
            return _konutTipiDAL.GetList();
        }

        public void Tupdate(KonutTipi t)
        {
            _konutTipiDAL.Update(t);
        }
    }
}
