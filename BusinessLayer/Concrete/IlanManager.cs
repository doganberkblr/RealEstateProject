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
    public class IlanManager : IIlanService
    {
        IIlanDAL _IlanDAL;
        IKullaniciDAL _KullaniciDAL;
        IKategoriDAL _KategoriDAL;
        IKonutTipiDAL _KonutTipiDAL;
        ISehirDAL _SehirDAL;

        public IlanManager(IIlanDAL ilanDAL, IKullaniciDAL kullaniciDAL, IKategoriDAL kategoriDAL, IKonutTipiDAL konutTipiDAL, ISehirDAL sehirDAL)
        {
            _IlanDAL = ilanDAL;
            _KullaniciDAL = kullaniciDAL;
            _KategoriDAL = kategoriDAL;
            _KonutTipiDAL = konutTipiDAL;
            _SehirDAL = sehirDAL;

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
            Ilan ilan = _IlanDAL.Get(id);
            ilan.kullanici=_KullaniciDAL.Get(ilan.KullaniciID);
            ilan.konutTipi=_KonutTipiDAL.Get(ilan.KonutTipiID);
            ilan.kategori=_KategoriDAL.Get(ilan.KategoriID);
            ilan.sehir=_SehirDAL.Get(ilan.SehirID);
            return ilan;
        }

        public Ilan ilanlariGetir(Ilan a)
        {
            Ilan ilan=_IlanDAL.Getir(a);
            ilan.kullanici = _KullaniciDAL.Get(ilan.KullaniciID);
            ilan.konutTipi = _KonutTipiDAL.Get(ilan.KonutTipiID);
            ilan.kategori = _KategoriDAL.Get(ilan.KategoriID);
            ilan.sehir = _SehirDAL.Get(ilan.SehirID);
            return ilan;
        }

        public List<Ilan> TgetList()
        {
           List<Ilan>ilanlar=_IlanDAL.GetList();
            for (int i = 0; i < ilanlar.Count; i++)
            {
                ilanlar[i].kullanici = _KullaniciDAL.Get(ilanlar[i].KullaniciID);
                ilanlar[i].kategori = _KategoriDAL.Get(ilanlar[i].KategoriID);
                ilanlar[i].sehir = _SehirDAL.Get(ilanlar[i].SehirID);
                ilanlar[i].konutTipi = _KonutTipiDAL.Get(ilanlar[i].KonutTipiID);
            }
            return ilanlar;
        }
        public List<Ilan>KullaniciyaAitIlanGetir(int id)
        {
            var liste = _IlanDAL.Getir(x => x.KullaniciID == id);
            foreach (var item in liste)
            {
                item.kullanici = _KullaniciDAL.Get(item.KullaniciID);
            }
            return liste;
        }
        public void Tupdate(Ilan t)
        {
            _IlanDAL.Update(t);
        }
    }
}
