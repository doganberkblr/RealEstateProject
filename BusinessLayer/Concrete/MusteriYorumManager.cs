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
    public class MusteriYorumManager : IMusteriYorumService
    {
        IMusteriYorumDAL _musteriYorumDAL;
        IKullaniciDAL _kullaniciDAL;
       
        public MusteriYorumManager(IMusteriYorumDAL musteriYorumDAL, IKullaniciDAL kullaniciDAL )
        {
                _musteriYorumDAL = musteriYorumDAL;
                _kullaniciDAL = kullaniciDAL;

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
            MusteriYorum yorum=_musteriYorumDAL.Get(id);
            yorum.kullanici = _kullaniciDAL.Get(yorum.KullaniciID);
            return yorum;
                
        }
        public MusteriYorum YorumGetir(MusteriYorum kg)
        {
           MusteriYorum yorum=_musteriYorumDAL.Getir(kg);
            yorum.kullanici = _kullaniciDAL.Get(yorum.KullaniciID);
            return yorum;
        }
        public List<MusteriYorum> TgetList()
        {
           List<MusteriYorum>yorumlar=_musteriYorumDAL.GetList();
            for (int i = 0; i < yorumlar.Count; i++)
            {
                yorumlar[i].kullanici = _kullaniciDAL.Get(yorumlar[i].KullaniciID);
            }
            return yorumlar;
        }
        public List<MusteriYorum> YorumGetirKullaniciyaAit(int id)
        {
            var liste = _musteriYorumDAL.Getir(x => x.KullaniciID == id);
            foreach (var item in liste)
            {
                item.kullanici = _kullaniciDAL.Get(item.KullaniciID);
              
            }
            return liste;
        }
        public void Tupdate(MusteriYorum t)
        {
           _musteriYorumDAL.Update(t);
        }
    }
}
