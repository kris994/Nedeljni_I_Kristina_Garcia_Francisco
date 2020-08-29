using Nedeljni_I_Kristina_Garcia_Francisco.Commands;
using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using Nedeljni_I_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.ViewModel
{
    /// <summary>
    /// Main Window view model
    /// </summary>
    class SuperAdminViewModel : BaseViewModel
    {
        SuperAdminWindow superAdmin;
        Service service = new Service();

        #region Constructor
        /// <summary>
        /// Constructor with SuperAdminWindow param
        /// </summary>
        /// <param name="SuperAdminWindow">opens the all uers window</param>
        public SuperAdminViewModel(SuperAdminWindow usersOpen)
        {
            superAdmin = usersOpen;
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            AllInfoAdminList = service.GetAllAdminsInfo().ToList();
            ManagerList = service.GetAllManagers().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            AdminList = service.GetAllAdmins().ToList();
            UserList = service.GetAllUsers().ToList();
        }
        #endregion

        #region Property
        /// <summary>
        /// List of users
        /// </summary>
        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

        /// <summary>
        /// List of managers
        /// </summary>
        private List<tblManager> managerList;
        public List<tblManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        /// <summary>
        /// List of employee
        /// </summary>
        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        /// <summary>
        /// List of admin
        /// </summary>
        private List<tblAdmin> adminList;
        public List<tblAdmin> AdminList
        {
            get
            {
                return adminList;
            }
            set
            {
                adminList = value;
                OnPropertyChanged("AdminList");
            }
        }

        /// <summary>
        /// List of managers info view
        /// </summary>
        private List<vwManager> allInfoManagerList;
        public List<vwManager> AllInfoManagerList
        {
            get
            {
                return allInfoManagerList;
            }
            set
            {
                allInfoManagerList = value;
                OnPropertyChanged("AllInfoManagerList");
            }
        }

        /// <summary>
        /// List of employee info view
        /// </summary>
        private List<vwEmployee> allInfoEmployeeList;
        public List<vwEmployee> AllInfoEmployeeList
        {
            get
            {
                return allInfoEmployeeList;
            }
            set
            {
                allInfoEmployeeList = value;
                OnPropertyChanged("AllInfoEmployeeList");
            }
        }

        /// <summary>
        /// List of admin info view
        /// </summary>
        private List<vwAdmin> allInfoAdminList;
        public List<vwAdmin> AllInfoAdminList
        {
            get
            {
                return allInfoAdminList;
            }
            set
            {
                allInfoAdminList = value;
                OnPropertyChanged("AllInfoAdminList");
            }
        }

        /// <summary>
        /// Specific Manager
        /// </summary>
        private vwManager manager;
        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        /// <summary>
        /// Specific Employee
        /// </summary>
        private vwEmployee employee;
        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }
        #endregion

        #region Commands     
        /// <summary>
        /// Command that tries to add a new admin
        /// </summary>
        private ICommand addNewAdmin;
        public ICommand AddNewAdmin
        {
            get
            {
                if (addNewAdmin == null)
                {
                    addNewAdmin = new RelayCommand(param => AddNewAdminExecute(), param => CanAddNewAdminExecute());
                }
                return addNewAdmin;
            }
        }

        /// <summary>
        /// Executes the add Admin command
        /// </summary>
        private void AddNewAdminExecute()
        {
            try
            {
                AddAdmin addAdmin = new AddAdmin();
                addAdmin.ShowDialog();
                if ((addAdmin.DataContext as AddUserViewModel).IsUpdateAdmin == true)
                {
                    AdminList = service.GetAllAdmins().ToList();
                    AllInfoAdminList = service.GetAllAdminsInfo().ToList();
                    UserList = service.GetAllUsers().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to add the new admin
        /// </summary>
        /// <returns>true</returns>
        private bool CanAddNewAdminExecute()
        {
            return true;
        }      

        /// <summary>
        /// Command that logs off the user
        /// </summary>
        private ICommand logoff;
        public ICommand Logoff
        {
            get
            {
                if (logoff == null)
                {
                    logoff = new RelayCommand(param => LogoffExecute(), param => CanLogoffExecute());
                }
                return logoff;
            }
        }

        /// <summary>
        /// Executes the logoff command
        /// </summary>
        private void LogoffExecute()
        {
            try
            {
                Login login = new Login();
                superAdmin.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to logoff
        /// </summary>
        /// <returns>true</returns>
        private bool CanLogoffExecute()
        {
            return true;
        }
        #endregion
    }
}
