﻿using BusinessLayer.Abstract;
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
    public class SehirManager : ISehirService
    {
        ISehirDAL _sehirDAL;
        public SehirManager(ISehirDAL sehirDAL)
        {
            _sehirDAL = sehirDAL;       
        }
        public void Tadd(Sehir t)
        {
            _sehirDAL.Insert(t);
        }

        public void Tdelete(Sehir t)
        {
            _sehirDAL.Delete(t);
        }

        public Sehir TgetByID(int id)
        {
            return _sehirDAL.Get(id);
        }
        public Sehir SehirGetir(Sehir t)
        {
            return _sehirDAL.Getir(t);
        }

        public List<Sehir> TgetList()
        {
            return _sehirDAL.GetList();
        }

        public void Tupdate(Sehir t)
        {
            _sehirDAL.Update(t);
        }
    }
}
