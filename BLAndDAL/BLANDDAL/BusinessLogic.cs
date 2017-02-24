using System;
using System.Web;
using System.Linq;
using System.Data.Entity;

namespace BLAndDAL.BLANDDAL
{
    public class BusinessLogic 
    {
        public user GetUserDetails(user user) {
            var ctx = new BHSIDBEntities();
            user.EMAIL_ID = "krishnappa.halemani@xceedance.com";
            user.PASSWORD = "9575979021b9d478fb940eae579f4c48";
            return ctx.Users.Single(u => u.EMAIL_ID == user.EMAIL_ID && u.PASSWORD == user.PASSWORD);
        }

        public user AddOrUpdateUserDetails(user user)
        {
            var ctx = new BHSIDBEntities();
            return ctx.Users.Add(user);
        }

        public group GetGroupDetails(group grp)
        {
            var ctx = new BHSIDBEntities();
            return (group)ctx.Groups.Select(g => g.GROUP_ID == grp.GROUP_ID);
        }

        public group AddOrUpdateGroupDetails(group grp)
        {
            var ctx = new BHSIDBEntities();
            return ctx.Groups.Add(grp);
        }

    }
}
