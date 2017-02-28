using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace BusinessLogic
{
    public class BHSIDBEntities : DbContext
    {
        public BHSIDBEntities() : base("name=BHSIEntities") { }

        public DbSet<user> Users { get; set; }
        public DbSet<Group> Groups { get; set; }


        public int LogError(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadLine();
            return 0;
        }


        public void LogSummery(user user)
        {
            ;
        }




        //public virtual ObjectResult<user> GetAllUsers()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user>("GetAllUsers");
        //}


        //public virtual ObjectResult<user> GetUserDetails(user user)
        //{
        //    var emailId = !string.IsNullOrEmpty(user.EMAIL_ID) ?
        //        new ObjectParameter("EMAIL_ID", user.EMAIL_ID) :
        //        new ("EMAIL_ID", typeof(string));

        //    var password = !string.IsNullOrEmpty(user.PASSWORD) ?
        //        new ObjectParameter("PASSWORD", user.PASSWORD) :
        //        new ObjectParameter("PASSWORD", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user>("sp_DeleteStudent", emailId, password);
        //}

        //public virtual ObjectResult<group> GetAllGroups()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<group>("GetAllGroups");
        //}

        //public virtual ObjectResult<group> GetGroupDetails(Nullable<int> groupId)
        //{
        //    var grpIdParameter = groupId.HasValue ?
        //       new ObjectParameter("groupId", groupId) :
        //       new ObjectParameter("groupId", typeof(int));


        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<group>("sp_DeleteStudent", grpIdParameter);
        //}

    }
}
