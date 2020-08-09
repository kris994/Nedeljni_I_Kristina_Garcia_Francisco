using Nedeljni_I_Kristina_Garcia_Francisco.Commands;
using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using Nedeljni_I_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        Login view;
        Service service = new Service();

        #region Constructor
        public LoginViewModel(Login loginView)
        {
            view = loginView;
            user = new tblUser();
            ManagerList = service.GetAllManagers().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            UserList = service.GetAllUsers().ToList();           
        }
        #endregion

        #region Property
        /// <summary>
        /// Login info label
        /// </summary>
        private string infoLabel;
        public string InfoLabel
        {
            get
            {
                return infoLabel;
            }
            set
            {
                infoLabel = value;
                OnPropertyChanged("InfoLabel");
            }
        }

        /// <summary>
        /// Used for saving the current user
        /// </summary>
        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        /// <summary>
        /// List of all users in the application
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
        #endregion

        #region Commands
        /// <summary>
        /// Command that tries to add a new employee
        /// </summary>
        private ICommand addNewEmployee;
        public ICommand AddNewEmployee
        {
            get
            {
                if (addNewEmployee == null)
                {
                    addNewEmployee = new RelayCommand(param => AddNewEmpoloyeeExecute(), param => CanAddNewEmployeeExecute());
                }
                return addNewEmployee;
            }
        }

        /// <summary>
        /// Executes the add Employee command
        /// </summary>
        private void AddNewEmpoloyeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.ShowDialog();
                if ((addEmployee.DataContext as AddUserViewModel).IsUpdateEmployee == true)
                {
                    EmployeeList = service.GetAllEmployees().ToList();
                    AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
                    UserList = service.GetAllUsers().ToList();
                    InfoLabel = "Created an employee";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to add the new employee
        /// </summary>
        /// <returns>true</returns>
        private bool CanAddNewEmployeeExecute()
        {
            if (!ManagerList.Any())
            {
                InfoLabel = "Cannot create employees\nMissing managers";
                return false;
            }
            else
            {
                return true;
            }         
        }

        /// <summary>
        /// Command that tries to add a new manager
        /// </summary>
        private ICommand addNewManager;
        public ICommand AddNewManager
        {
            get
            {
                if (addNewManager == null)
                {
                    addNewManager = new RelayCommand(param => AddNewManagerExecute(), param => CanAddNewManagerExecute());
                }
                return addNewManager;
            }
        }

        /// <summary>
        /// Executes the add Manager command
        /// </summary>
        private void AddNewManagerExecute()
        {
            try
            {
                AddManager addManager = new AddManager();
                addManager.ShowDialog();
                if ((addManager.DataContext as AddUserViewModel).IsUpdateManager == true)
                {
                    ManagerList = service.GetAllManagers().ToList();
                    AllInfoManagerList = service.GetAllManagersInfo().ToList();
                    UserList = service.GetAllUsers().ToList();
                    InfoLabel = "Created a manager";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to add the new manager
        /// </summary>
        /// <returns>true</returns>
        private bool CanAddNewManagerExecute()
        {
            return true;
        }

        /// <summary>
        /// Command used to log te user into the application
        /// </summary>
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
        }

        /// <summary>
        /// Checks if its possible to login depending on the given username and password and saves the logged in user to a list
        /// </summary>
        /// <param name="obj"></param>
        private void LoginExecute(object obj)
        {
            string password = (obj as PasswordBox).Password;
            bool found = false;
            if (User.Username == "WPFMaster" && password == "WPFAccess")
            {
                InfoLabel = "Logged in";

                SuperAdminWindow superAdmin = new SuperAdminWindow();
                view.Close();
                superAdmin.Show();
            }
            else if (UserList.Any())
            {
                for (int i = 0; i < UserList.Count; i++)
                {
                    if (User.Username == UserList[i].Username && password == UserList[i].UserPassword)
                    {
                        LoggedUser.CurrentUser = new tblUser
                        {
                            UserID = UserList[i].UserID,
                            FirstName = UserList[i].FirstName,
                            LastName = UserList[i].LastName,
                            JMBG = UserList[i].JMBG,
                            Gender = UserList[i].Gender,
                            Residence = UserList[i].Residence,
                            MarriageStatus = UserList[i].MarriageStatus,
                            Username = UserList[i].Username,
                            UserPassword = UserList[i].UserPassword
                        };
                        InfoLabel = "Logged in";
                        found = true;
                        if (service.GetAllManagers().Any(id => id.UserID == UserList[i].UserID) == true)
                        {
                            ManagerWindow managerWindow = new ManagerWindow();
                            view.Close();
                            managerWindow.Show();
                        }
                        else if (service.GetAllEmployees().Any(id => id.UserID == UserList[i].UserID) == true)
                        {
                            EmployeeWindow emp = new EmployeeWindow();
                            view.Close();
                            emp.Show();
                        }
                        else if (service.GetAllAdmins().Any(id => id.UserID == UserList[i].UserID) == true)
                        {
                            AdminWindow admin = new AdminWindow();
                            view.Close();
                            admin.Show();
                        }
                        break;
                    }
                }

                // Reserve password
                for (int i = 0; i < ManagerList.Count; i++)
                {
                    string managerUsername = service.GetAllUsers().Where(id => id.UserID == ManagerList[i].UserID).Select(user => user.Username).FirstOrDefault();
                    if (User.Username == managerUsername && password == ManagerList[i].ReservedPassword)
                    {
                        found = true;
                        ManagerWindow managerWindow = new ManagerWindow();
                        view.Close();
                        managerWindow.Show();
                        break;
                    }
                }

                if (found == false)
                {

                    InfoLabel = "Wrong Username or Password";
                }
            }
        }
        #endregion
    }
}
