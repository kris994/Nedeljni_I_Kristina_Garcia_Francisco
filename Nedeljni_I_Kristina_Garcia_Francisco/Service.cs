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
        /// Gets all admins
        /// </summary>
        /// <returns>a list of found admins</returns>
        public List<tblAdmin> GetAllAdmins()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<tblAdmin> list = new List<tblAdmin>();
                    list = (from x in context.tblAdmins select x).ToList();
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
        /// Gets all information about admins
        /// </summary>
        /// <returns>a list of found admins</returns>
        public List<vwAdmin> GetAllAdminsInfo()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<vwAdmin> list = new List<vwAdmin>();
                    list = (from x in context.vwAdmins select x).ToList();
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
        /// Gets all information about positions
        /// </summary>
        /// <returns>a list of found positions</returns>
        public List<tblPosition> GetAllPosition()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<tblPosition> list = new List<tblPosition>();
                    list = (from x in context.tblPositions select x).ToList();
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
        /// Gets all information about sectors
        /// </summary>
        /// <returns>a list of found sectors</returns>
        public List<tblSector> GetAllSectors()
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    List<tblSector> list = new List<tblSector>();
                    list = (from x in context.tblSectors select x).ToList();
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

        /// <summary>
        /// Creates or edits an employee
        /// </summary>
        /// <param name="employee">the employee that is being added</param>
        /// <returns>a new or edited employee</returns>
        public vwEmployee AddEmployee(vwEmployee employee)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    if (employee.UserID == 0)
                    {
                        tblUser newUser = new tblUser
                        {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            JMBG = employee.JMBG,
                            Gender = employee.Gender,
                            Residence = employee.Residence,
                            MarriageStatus = employee.MarriageStatus,
                            Username = employee.Username,
                            UserPassword = employee.UserPassword
                        };

                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        employee.UserID = newUser.UserID;

                        //TODO remove when method to create sectors is made
                        if (employee.SectorID == 0)
                        {
                            tblSector sec = new tblSector
                            {
                                SectorName = "Default",
                                SectorDescription = "Default"
                            };
                            AddSector(sec);
                            employee.SectorID = sec.SectorID;
                        }

                        tblEmployee newEmployee = new tblEmployee
                        {
                            YearsOfService = employee.YearsOfService,
                            Salary = employee.Salary,
                            EducationDegree = employee.EducationDegree,
                            SectorID = employee.SectorID,
                            ManagerID = employee.ManagerID,
                            PositionID = employee.PositionID,
                            UserID = employee.UserID
                        };

                        context.tblEmployees.Add(newEmployee);
                        context.SaveChanges();
                        employee.EmployeeID = newEmployee.EmployeeID;

                        return employee;
                    }
                    else
                    {
                        tblUser userToEdit = (from ss in context.tblUsers where ss.UserID == employee.UserID select ss).First();

                        userToEdit.FirstName = employee.FirstName;
                        userToEdit.LastName = employee.LastName;
                        userToEdit.JMBG = employee.JMBG;
                        userToEdit.Gender = employee.Gender;
                        userToEdit.Residence = employee.Residence;
                        userToEdit.MarriageStatus = employee.MarriageStatus;
                        userToEdit.Username = employee.Username;
                        userToEdit.UserPassword = employee.UserPassword;

                        userToEdit.UserID = employee.UserID;

                        tblUser userEdit = (from ss in context.tblUsers
                                            where ss.UserID == employee.UserID
                                            select ss).First();
                        context.SaveChanges();

                        tblEmployee employeeToEdit = (from ss in context.tblEmployees where ss.UserID == employee.UserID select ss).First();

                        employeeToEdit.YearsOfService = employee.YearsOfService;
                        employeeToEdit.Salary = employee.Salary;
                        employeeToEdit.EducationDegree = employee.EducationDegree;
                        employeeToEdit.SectorID = employee.SectorID;
                        employeeToEdit.ManagerID = employee.ManagerID;
                        employeeToEdit.PositionID = employee.PositionID;
                        employeeToEdit.UserID = employee.UserID;

                        employeeToEdit.EmployeeID = employee.EmployeeID;

                        tblEmployee employeeEdit = (from ss in context.tblEmployees
                                                    where ss.EmployeeID == employee.EmployeeID
                                                    select ss).First();
                        context.SaveChanges();
                        return employee;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Creates or edits a manager
        /// </summary>
        /// <param name="manager">the manager that is esing added</param>
        /// <returns>a new or edited manager</returns>
        public vwManager AddManager(vwManager manager)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    if (manager.UserID == 0)
                    {
                        tblUser newUser = new tblUser
                        {
                            FirstName = manager.FirstName,
                            LastName = manager.LastName,
                            JMBG = manager.JMBG,
                            Gender = manager.Gender,
                            Residence = manager.Residence,
                            MarriageStatus = manager.MarriageStatus,
                            Username = manager.Username,
                            UserPassword = manager.UserPassword
                        };

                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        manager.UserID = newUser.UserID;

                        tblManager newManager = new tblManager
                        {
                            Email = manager.Email,
                            ReservedPassword = manager.ReservedPassword + "WPF",
                            LevelOfResponsibility = manager.LevelOfResponsibility,
                            SuccessfulProjects = manager.SuccessfulProjects,
                            Salary = manager.Salary,
                            OfficeNumber = manager.OfficeNumber,
                            UserID = manager.UserID
                        };

                        context.tblManagers.Add(newManager);
                        context.SaveChanges();
                        manager.ManagerID = newManager.ManagerID;

                        return manager;
                    }
                    else
                    {
                        tblUser userToEdit = (from ss in context.tblUsers where ss.UserID == manager.UserID select ss).First();

                        userToEdit.FirstName = manager.FirstName;
                        userToEdit.LastName = manager.LastName;
                        userToEdit.JMBG = manager.JMBG;
                        userToEdit.Gender = manager.Gender;
                        userToEdit.Residence = manager.Residence;
                        userToEdit.MarriageStatus = manager.MarriageStatus;
                        userToEdit.Username = manager.Username;
                        userToEdit.UserPassword = manager.UserPassword;

                        userToEdit.UserID = manager.UserID;

                        tblUser userEdit = (from ss in context.tblUsers
                                            where ss.UserID == manager.UserID
                                            select ss).First();
                        context.SaveChanges();

                        tblManager managerToEdit = (from ss in context.tblManagers where ss.UserID == manager.UserID select ss).First();

                        managerToEdit.Email = manager.Email;
                        managerToEdit.ReservedPassword = manager.ReservedPassword;
                        managerToEdit.LevelOfResponsibility = manager.LevelOfResponsibility;
                        managerToEdit.SuccessfulProjects = manager.SuccessfulProjects;
                        managerToEdit.Salary = manager.Salary;
                        managerToEdit.OfficeNumber = manager.OfficeNumber;
                        managerToEdit.UserID = manager.UserID;

                        managerToEdit.ManagerID = manager.ManagerID;

                        tblManager managerEdit = (from ss in context.tblManagers
                                                  where ss.ManagerID == manager.ManagerID
                                                  select ss).First();
                        context.SaveChanges();
                        return manager;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Creates or edits a admin
        /// </summary>
        /// <param name="admin">the admin that is esing added</param>
        /// <returns>a new or edited admin</returns>
        public vwAdmin AddAdmin(vwAdmin admin)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    if (admin.UserID == 0)
                    {
                        tblUser newUser = new tblUser
                        {
                            FirstName = admin.FirstName,
                            LastName = admin.LastName,
                            JMBG = admin.JMBG,
                            Gender = admin.Gender,
                            Residence = admin.Residence,
                            MarriageStatus = admin.MarriageStatus,
                            Username = admin.Username,
                            UserPassword = admin.UserPassword
                        };

                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        admin.UserID = newUser.UserID;

                        tblAdmin newAdmin = new tblAdmin
                        {
                            ExpirationDate = DateTime.Now.AddDays(7),
                            AdminType = admin.AdminType,
                            UserID = admin.UserID
                        };

                        context.tblAdmins.Add(newAdmin);
                        context.SaveChanges();
                        admin.AdminID = newAdmin.AdminID;

                        return admin;
                    }
                    else
                    {
                        tblUser userToEdit = (from ss in context.tblUsers where ss.UserID == admin.UserID select ss).First();

                        userToEdit.FirstName = admin.FirstName;
                        userToEdit.LastName = admin.LastName;
                        userToEdit.JMBG = admin.JMBG;
                        userToEdit.Gender = admin.Gender;
                        userToEdit.Residence = admin.Residence;
                        userToEdit.MarriageStatus = admin.MarriageStatus;
                        userToEdit.Username = admin.Username;
                        userToEdit.UserPassword = admin.UserPassword;

                        userToEdit.UserID = admin.UserID;

                        tblUser userEdit = (from ss in context.tblUsers
                                            where ss.UserID == admin.UserID
                                            select ss).First();
                        context.SaveChanges();

                        tblAdmin adminToEdit = (from ss in context.tblAdmins where ss.UserID == admin.UserID select ss).First();

                        adminToEdit.ExpirationDate = admin.ExpirationDate;
                        adminToEdit.AdminType = admin.AdminType;
                        adminToEdit.UserID = admin.UserID;

                        adminToEdit.AdminID = admin.AdminID;

                        context.SaveChanges();
                        return admin;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        /// <summary>
        /// Creates or edits an sector
        /// </summary>
        /// <param name="sector">the sector that is being added</param>
        /// <returns>a new or edited sector</returns>
        public tblSector AddSector(tblSector sector)
        {
            try
            {
                using (CompanyDBEntities context = new CompanyDBEntities())
                {
                    if (sector.SectorID == 0)
                    {
                        tblSector newSector = new tblSector
                        {
                            SectorName = sector.SectorName,
                            SectorDescription = sector.SectorDescription
                        };

                        context.tblSectors.Add(newSector);
                        context.SaveChanges();
                        sector.SectorID = newSector.SectorID;

                        return sector;
                    }
                    else
                    {
                        tblSector sectorToEdit = (from ss in context.tblSectors where ss.SectorID == sector.SectorID select ss).First();

                        sectorToEdit.SectorName = sector.SectorName;
                        sectorToEdit.SectorName = sector.SectorName;

                        sectorToEdit.SectorID = sector.SectorID;
                        context.SaveChanges();

                        return sector;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
