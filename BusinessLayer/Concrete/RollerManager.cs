using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RollerManager : IRollerService
    {
        IRollerDal _rollerDal;

        public RollerManager(IRollerDal rollerDal)
        {
            _rollerDal = rollerDal;
        }

        public List<Roller> GetRoles()
        {
            return _rollerDal.List();
        }
    }
}