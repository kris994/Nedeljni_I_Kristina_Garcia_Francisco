using Nedeljni_I_Kristina_Garcia_Francisco.Commands;
using Nedeljni_I_Kristina_Garcia_Francisco.Helper;
using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using Nedeljni_I_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        Login view;
        EnterCode enterCodeView;
        FileReadWrite fileReadWrite = new FileReadWrite();
        Service service = new Service();
        private static bool firstTimeOpened = true;
        private static int counter = 3;

        #region Constructor
        /// <summary>
        /// Login Window
        /// </summary>
        /// <param name="loginView">Login View</param>
        public LoginViewModel(Login loginView)
        {
            view = loginView;
            user = new tblUser();
            fileReadWrite.OnNotification += fileReadWrite.GenerateRandomNmuberToFile;
            ManagerList = service.GetAllManagers().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            UserList = service.GetAllUsers().ToList();
            AddManagerVisible = Visibility.Visible;

            // Only generate the number when the app is opened for the first time
            if (firstTimeOpened == true)
            {
                fileReadWrite.Notify();
                firstTimeOpened = false;
            }
        }

        /// <summary>
        /// Enter Code Window
        /// </summary>
        /// <param name="enterCodeOpen">Enter Code view</param>
        public LoginViewModel(EnterCode enterCodeOpen)
        {
            enterCodeView = enterCodeOpen;
            CodeInfoLabel = "Total amount of tries left: " + counter;
            user = new tblUser();
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
        /// Code counter into label
        /// </summary>
        private string codeInfoLabel;
        public string CodeInfoLabel
        {
            get
            {
                return codeInfoLabel;
            }
            set
            {
                codeInfoLabel = value;
                OnPropertyChanged("CodeInfoLabel");
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

        /// <summary>
        /// Code
        /// </summary>
        private string code;
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        /// <summary>
        /// AddManager Visibility
        /// </summary>
        private Visibility addManagerVisible;
        public Visibility AddManagerVisible
        {
            get
            {
                return addManagerVisible;
            }
            set
            {
                addManagerVisible = value;
                OnPropertyChanged("AddManagerVisible");
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
        /// Button for entering manager code
        /// </summary>
        private ICommand managerCode;
        public ICommand ManagerCode
        {
            get
            {
                if (managerCode == null)
                {
                    managerCode = new RelayCommand(param => ManagerCodeExecute(), param => CanManagerCodeExecute());
                }
                return managerCode;
            }
        }

        /// <summary>
        /// Executes the manager code
        /// </summary>
        private void ManagerCodeExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to create a manager account?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (dialog == MessageBoxResult.Yes)
            {
                try
                {
                    enterCodeView = new EnterCode();
                    enterCodeView.ShowDialog();

                    if (AddUserViewModel.IsUpdateManager == true)
                    {
                        InfoLabel = "Created a manager";
                        ManagerList = service.GetAllManagers().ToList();
                        AllInfoManagerList = service.GetAllManagersInfo().ToList();
                        UserList = service.GetAllUsers().ToList();
                        AddUserViewModel.IsUpdateManager = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                return;
            }
        }


        /// <summary>
        /// Checks if its possible to press the button
        /// </summary>
        /// <returns>true</returns>
        private bool CanManagerCodeExecute()
        {
            if (counter > 0)
            {
                return true;
            }
            else
            {
                AddManagerVisible = Visibility.Collapsed;
                return false;
            }
        }

        /// <summary>
        /// Command that tries to open manager window
        /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                int value = fileReadWrite.ReadRandomNumberFIle();

                if (value.ToString() != Code)
                {
                    counter--;
                    CodeInfoLabel = "Total amount of tries left: " + counter;
                }
                else if (value.ToString() == Code)
                {
                    try
                    {
                        AddManager addManager = new AddManager();
                        enterCodeView.Close();
                        addManager.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                if (counter <= 0)
                {
                    enterCodeView.InfoMessage.Height = 60;
                    CodeInfoLabel = "Cannot create manager account\nplease continue by creating an Employee account.";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save
        /// </summary>
        protected bool CanSaveExecute()
        {
            if (counter > 0 && Code != null && Code.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Command that closes the add worker or edit worker window
        /// </summary>
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        /// <summary>
        /// Executes the close command
        /// </summary>
        private void CancelExecute()
        {
            enterCodeView.Close();
        }

        /// <summary>
        /// Checks if its possible to execute the close command
        /// </summary>
        /// <returns>true</returns>
        private bool CanCancelExecute()
        {
            return true;
        }

        /// <summary>
        /// Exit button
        /// </summary>
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exits the current window
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to stop?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (dialog == MessageBoxResult.Yes)
            {
                enterCodeView.Close();
            }
        }

        /// <summary>
        /// Checks if its possible to press the button
        /// </summary>
        /// <returns></returns>
        private bool CanExitExecute()
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
                    if (User.Username == UserList[i].Username && PasswordHasher.Verify(password, UserList[i].UserPassword) == true)
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
