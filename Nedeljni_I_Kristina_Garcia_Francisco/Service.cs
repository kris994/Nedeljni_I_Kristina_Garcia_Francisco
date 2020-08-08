using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Nedeljni_I_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Class that includes all CRUD functions of the application
    /// </summary>
    class Service
    {
        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// Gets all managers
        /// </summary>
        /// <returns>a list of found managers</returns>
        public List<tblManager> GetAllManagers()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<tblManager> list = new List<tblManager>();
                    list = (from x in context.tblManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>a list of found employees</returns>
        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about managers
        /// </summary>
        /// <returns>a list of found managers</returns>
        public List<vwManager> GetAllManagersInfo()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about employees
        /// </summary>
        /// <returns>a list of found employees</returns>
        public List<vwEmployee> GetAllEmployeesInfo()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Search if user with that ID exists in the user table
        /// </summary>
        /// <param name="userID">Takes the user id that we want to search for</param>
        /// <returns>True if the user exists</returns>
        public bool IsUserID(int userID)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    int result = (from x in context.tblUsers where x.UserID == userID select x.UserID).FirstOrDefault();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception " + ex.Message.ToString());
                return false;
            }
        }

    }
}
