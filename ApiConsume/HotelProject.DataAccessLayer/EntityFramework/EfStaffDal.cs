using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal:GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        { 

        }

        public int GetStaffCount()
        {
            using var context = new Context();
            var value= context.Staffs.Count();
            return value;
        }
    }
}
