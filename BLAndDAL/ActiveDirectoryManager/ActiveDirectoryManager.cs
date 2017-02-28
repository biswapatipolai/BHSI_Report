using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Configuration;
using BusinessLogic.BusinessLogic;
using BusinessLogic;


//namespace BusinessLogic.ActiveDirectoryManager.ActiveDirectoryManager
//{
//    public class ActiveDirectoryManager
//    {
//        #region Variables

//private string sDomain = "xipl.local";
//private string sDefaultOU = "OU=Xceedance,DC=xipl,DC=local";
//private string sDefaultRootOU = "DC=xipl,DC=local";
//private string sServiceUser = @"dummy1";
//private string sServicePassword = @"green@123";

//        private string sDomain = ConfigurationManager.AppSettings["sDomain"];
//        private string sDefaultOU = ConfigurationManager.AppSettings["sDefaultOU"];
//        private string sDefaultRootOU = ConfigurationManager.AppSettings["sDefaultRootOU"];
//        private string sServiceUser = ConfigurationManager.AppSettings["sServiceUser"];
//        private string sServicePassword = ConfigurationManager.AppSettings["sServicePassword"];

//        //private string sDomain = "test.com";
//        //private string sDefaultOU = "OU=Test Users,OU=Test,DC=test,DC=com";
//        //private string sDefaultRootOU = "DC=test,DC=com";
//        //private string sServiceUser = @"ServiceUser";
//        //private string sServicePassword = "ServicePassword";

//        #endregion

//        #region Validate Methods



//        /// <summary>
//        /// Deletes a user in Active Directory
//        /// </summary>
//        /// <param name="sUserName">The username you want to delete</param>
//        /// <returns>Returns true if successfully deleted</returns>
//        private bool DeleteUser(string sUserName)
//        {
//            try
//            {
//                UserPrincipal oUserPrincipal = GetUser(sUserName);

//                oUserPrincipal.Delete();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        #endregion

//        #region Group Methods

//        /// <summary>
//        /// Creates a new group in Active Directory
//        /// </summary>
//        /// <param name="sOU">The OU location you want to save your new Group</param>
//        /// <param name="sGroupName">The name of the new group</param>
//        /// <param name="sDescription">The description of the new group</param>
//        /// <param name="oGroupScope">The scope of the new group</param>
//        /// <param name="bSecurityGroup">True is you want this group to be a security group, false if you want this as a distribution group</param>
//        /// <returns>Retruns the GroupPrincipal object</returns>
//        private GroupPrincipal CreateNewGroup(string sOU, string sGroupName, string sDescription, GroupScope oGroupScope, bool bSecurityGroup)
//        {
//            PrincipalContext oPrincipalContext = GetPrincipalContext(sOU);

//            GroupPrincipal oGroupPrincipal = new GroupPrincipal(oPrincipalContext, sGroupName);
//            oGroupPrincipal.Description = sDescription;
//            oGroupPrincipal.GroupScope = oGroupScope;
//            oGroupPrincipal.IsSecurityGroup = bSecurityGroup;
//            oGroupPrincipal.Save();

//            return oGroupPrincipal;
//        }

//        /// <summary>
//        /// Adds the user for a given group
//        /// </summary>
//        /// <param name="sUserName">The user you want to add to a group</param>
//        /// <param name="sGroupName">The group you want the user to be added in</param>
//        /// <returns>Returns true if successful</returns>
//        private bool AddUserToGroup(string sUserName, string sGroupName)
//        {
//            try
//            {
//                UserPrincipal oUserPrincipal = GetUser(sUserName);
//                GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
//                if (oUserPrincipal != null && oGroupPrincipal != null)
//                {
//                    if (!IsUserGroupMember(sUserName, sGroupName))
//                    {
//                        oGroupPrincipal.Members.Add(oUserPrincipal);
//                        oGroupPrincipal.Save();
//                    }
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Removes user from a given group
//        /// </summary>
//        /// <param name="sUserName">The user you want to remove from a group</param>
//        /// <param name="sGroupName">The group you want the user to be removed from</param>
//        /// <returns>Returns true if successful</returns>
//        private bool RemoveUserFromGroup(string sUserName, string sGroupName)
//        {
//            try
//            {
//                UserPrincipal oUserPrincipal = GetUser(sUserName);
//                GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
//                if (oUserPrincipal != null && oGroupPrincipal != null)
//                {
//                    if (IsUserGroupMember(sUserName, sGroupName))
//                    {
//                        oGroupPrincipal.Members.Remove(oUserPrincipal);
//                        oGroupPrincipal.Save();
//                    }
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Checks if user is a member of a given group
//        /// </summary>
//        /// <param name="sUserName">The user you want to validate</param>
//        /// <param name="sGroupName">The group you want to check the membership of the user</param>
//        /// <returns>Returns true if user is a group member</returns>
//        private bool IsUserGroupMember(string sUserName, string sGroupName)
//        {
//            UserPrincipal oUserPrincipal = GetUser(sUserName);
//            GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);

//            if (oUserPrincipal != null && oGroupPrincipal != null)
//            {
//                return oGroupPrincipal.Members.Contains(oUserPrincipal);
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Gets a list of the users group memberships
//        /// </summary>
//        /// <param name="sUserName">The user you want to get the group memberships</param>
//        /// <returns>Returns an arraylist of group memberships</returns>
//        private ArrayList GetUserGroups(string sUserName)
//        {
//            ArrayList myItems = new ArrayList();
//            UserPrincipal oUserPrincipal = GetUser(sUserName);

//            PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetGroups();

//            foreach (Principal oResult in oPrincipalSearchResult)
//            {
//                myItems.Add(oResult.Name);
//            }
//            return myItems;
//        }

//        /// <summary>
//        /// Gets a list of the users authorization groups
//        /// </summary>
//        /// <param name="sUserName">The user you want to get authorization groups</param>
//        /// <returns>Returns an arraylist of group authorization memberships</returns>
//        private ArrayList GetUserAuthorizationGroups(string sUserName)
//        {
//            ArrayList myItems = new ArrayList();
//            UserPrincipal oUserPrincipal = GetUser(sUserName);

//            PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetAuthorizationGroups();

//            foreach (Principal oResult in oPrincipalSearchResult)
//            {
//                myItems.Add(oResult.Name);
//            }
//            return myItems;
//        }

//        #endregion

//        #region Helper Methods



//        /// <summary>
//        /// Gets the principal context on specified OU
//        /// </summary>
//        /// <param name="sOU">The OU you want your Principal Context to run on</param>
//        /// <returns>Retruns the PrincipalContext object</returns>
//        private PrincipalContext GetPrincipalContext(string sOU)
//        {
//            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sOU, ContextOptions.SimpleBind, sServiceUser, sServicePassword);
//            return oPrincipalContext;
//        }

//        #endregion



//    }
//}


namespace System.DirectoryServices.AccountManagement
{
  
    public class ActiveDirectoryManager
    {
        #region Variables

        private string sDomain = "xipl.local";
        private string sDefaultOU = "OU=Xceedance,DC=xipl,DC=local";
        private string sDefaultRootOU = "DC=xipl,DC=local";
        private string sServiceUser = @"dummy3";
        private string sServicePassword = @"green@123";

        //private string sDomain = ConfigurationManager.AppSettings["sDomain"];
        //private string sDefaultOU = ConfigurationManager.AppSettings["sDefaultOU"];
        //private string sDefaultRootOU = ConfigurationManager.AppSettings["sDefaultRootOU"];
        //private string sServiceUser = ConfigurationManager.AppSettings["sServiceUser"];
        //private string sServicePassword = ConfigurationManager.AppSettings["sServicePassword"];

        //private string sDomain = "test.com";
        //private string sDefaultOU = "OU=Test Users,OU=Test,DC=test,DC=com";
        //private string sDefaultRootOU = "DC=test,DC=com";
        //private string sServiceUser = @"ServiceUser";
        //private string sServicePassword = "ServicePassword";

        #endregion

        #region Methods

        /// <summary>
        /// Validates the username and password of a given user
        /// </summary>
        /// <param name="sUserName">The username to validate</param>
        /// <param name="sPassword">The password of the username to validate</param>
        /// <returns>Returns True of user is valid</returns>
        private bool ValidateCredentials(string sUserName, string sPassword)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();
            return oPrincipalContext.ValidateCredentials(sUserName, sPassword);
        }


        /// <summary>
        /// Checks if the User Account is Expired
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if Expired</returns>
        private bool IsUserExpired(UserPrincipal oUserPrincipal)
        {
            if (oUserPrincipal.AccountExpirationDate.HasValue)
            {
                if (oUserPrincipal.AccountExpirationDate < DateTime.Now)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if user exsists on AD
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if username Exists</returns>
        private bool IsUserExisiting(string sUserName)
        {
            if (GetUser(sUserName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validated credentials and checks lockout, disabled, expired atrributes
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        private UserPrincipal CheckUser(string username, string password)
        {

            if (ValidateCredentials(username, password))
            {
                var user = GetUser(username);

                if (user.IsAccountLockedOut() || IsUserExpired(user) || (!user.Enabled ?? false))
                    return null;

                return user;
            }
            else return null;

        }


        /// <summary>
        /// Creates a new user on Active Directory
        /// </summary>
        /// <param name="sOU">The OU location you want to save your user</param>
        /// <param name="sUserName">The username of the new user</param>
        /// <param name="sPassword">The password of the new user</param>
        /// <param name="sGivenName">The given name of the new user</param>
        /// <param name="sSurname">The surname of the new user</param>
        /// <returns>returns the UserPrincipal object</returns>
        private UserPrincipal CreateNewUser(string sOU, string sUserName, string sPassword, string sGivenName, string sSurname)
        {
            if (!IsUserExisiting(sUserName))
            {
                PrincipalContext oPrincipalContext = GetPrincipalContext(sOU);

                UserPrincipal oUserPrincipal = new UserPrincipal(oPrincipalContext, sUserName, sPassword, true /*Enabled or not*/);

                //User Log on Name
                oUserPrincipal.UserPrincipalName = sUserName;
                oUserPrincipal.GivenName = sGivenName;
                oUserPrincipal.Surname = sSurname;
                oUserPrincipal.Save();

                return oUserPrincipal;
            }
            else
            {
                return GetUser(sUserName);
            }
        }

        /// <summary>
        /// Gets a certain user on Active Directory
        /// </summary>
        /// <param name="sUserName">The username to get</param>
        /// <returns>Returns the UserPrincipal Object</returns>
        private UserPrincipal GetUser(string sUserName)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();

            if (oPrincipalContext == null)
                return null;
            else
            {
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
                return oUserPrincipal;
            }
        }

        public UserPrincipal GetUserDetails(string email)
        {
            return GetUser(email);
        }

        /// <summary>
        /// Gets the base principal context
        /// </summary>
        /// <returns>Retruns the PrincipalContext object</returns>
        private PrincipalContext GetPrincipalContext()
        {
            try
            {
                PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sDefaultOU, ContextOptions.SimpleBind, sServiceUser, sServicePassword);
                return oPrincipalContext;
            }
            catch (PrincipalServerDownException ex)
            {
                if (ConfigurationManager.AppSettings["ServerType"] == "Development") return null;
                else throw ex;
            }
        }
        private PrincipalContext GetPrincipalContext(string sOU)
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sOU, ContextOptions.SimpleBind, sServiceUser, sServicePassword);
            return oPrincipalContext;
        }

        #endregion
    }

}