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
    public class HakkindaManager : IHakkindaService
    {
        IHakkindaDAL _hakkindaDAL;
        public HakkindaManager(IHakkindaDAL hakkindaDAL)
        {
              _hakkindaDAL = hakkindaDAL;
        }
        public void Tadd(Hakkinda t)
        {
            _hakkindaDAL.Insert(t);
        }

        public void Tdelete(Hakkinda t)
        {
            _hakkindaDAL.Delete(t);
        }

        public Hakkinda TgetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hakkinda> TgetList()
        {
            return _hakkindaDAL.GetList();
        }

        public void Tupdate(Hakkinda t)
        {
            _hakkindaDAL.Update(t);
        }
    }
}
