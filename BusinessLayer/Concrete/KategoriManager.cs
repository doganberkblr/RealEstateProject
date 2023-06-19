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
    public class KategoriManager : IKategoriService
    {
        IKategoriDAL _kategoriDAL;
        public KategoriManager(IKategoriDAL kategoriDAL)
        {
                _kategoriDAL = kategoriDAL;
        }
        public void Tadd(Kategori t)
        {
            _kategoriDAL.Insert(t);
        }

        public void Tdelete(Kategori t)
        {
          _kategoriDAL.Delete(t);
        }

        public Kategori TgetByID(int id)
        {
            return _kategoriDAL.Get(id);
        }

        public Kategori KategoriGetir(Kategori t)
        {
            return _kategoriDAL.Getir(t);
        }

        public List<Kategori> TgetList()
        {
           return _kategoriDAL.GetList();
        }

        public void Tupdate(Kategori t)
        {
           _kategoriDAL.Update(t);
        }
    }
}
