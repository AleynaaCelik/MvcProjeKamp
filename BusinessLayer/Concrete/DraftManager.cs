using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }



        public void Add(Draft draft)
        {
            throw new NotImplementedException();
        }

        public void Delete(Draft draft)
        {
            throw new NotImplementedException();
        }

        public Draft GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Draft> GetList()
        {
            return _draftDal.List();
        }

        public void Update(Draft draft)
        {
            throw new NotImplementedException();
        }
    }
}
