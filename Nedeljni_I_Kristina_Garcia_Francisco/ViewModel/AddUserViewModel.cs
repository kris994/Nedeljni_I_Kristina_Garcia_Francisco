using Nedeljni_I_Kristina_Garcia_Francisco.Commands;
using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using Nedeljni_I_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.ViewModel
{
    class AddUserViewModel : BaseViewModel
    {
        AddEmployee addEmployee;
        AddManager addManager;
        AddAdmin addAdmin;
        Service service = new Service();

        #region Constructor
        /// <summary>
        /// Constructor with the add employee info window opening
        /// </summary>
        /// <param name="addEmployeeOpen">opends the add employee window</param>
        public AddUserViewModel(AddEmployee addEmployeeOpen)
        {
            employee = new vwEmployee();
            addEmployee = addEmployeeOpen;
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            UserList = service.GetAllUsers().ToList();
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            PositionList = service.GetAllPosition().ToList();
            SectorList = service.GetAllSectors().ToList();
        }

        /// <summary>
        /// Constructor with edit employee window opening
        /// </summary>
        /// <param name="addEmployeeOpen">opens the edit employee window</param>
        /// <param name="employeeEdit">gets the employee info that is being edited</param>
        public AddUserViewModel(AddEmployee addEmployeeOpen, vwEmployee employeeEdit)
        {
            employee = employeeEdit;
            addEmployee = addEmployeeOpen;
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            UserList = service.GetAllUsers().ToList();
        }

        /// <summary>
        /// Constructor with the add manager info window opening
        /// </summary>
        /// <param name="addManagerOpen">opends the add manager window</param>
        public AddUserViewModel(AddManager addManagerOpen)
        {
            manager = new vwManager();
            addManager = addManagerOpen;
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            ManagerList = service.GetAllManagers().ToList();
            UserList = service.GetAllUsers().ToList();
        }

        /// <summary>
        /// Constructor with edit manager window opening
        /// </summary>
        /// <param name="addManagerOpen">opens the edit manager window</param>
        /// <param name="managerEdit">gets the manager info that is being edited</param>
        public AddUserViewModel(AddManager addManagerOpen, vwManager managerEdit)
        {
            manager = managerEdit;
            addManager = addManagerOpen;
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            ManagerList = service.GetAllManagers().ToList();
            UserList = service.GetAllUsers().ToList();
        }

        /// <summary>
        /// Constructor with the add admin info window opening
        /// </summary>
        /// <param name="addAdminOpen">opends the add admin window</param>
        public AddUserViewModel(AddAdmin addAdminOpen)
        {
            admin = new vwAdmin();
            addAdmin = addAdminOpen;
            AllInfoAdminList = service.GetAllAdminsInfo().ToList();
            AdminList = service.GetAllAdmins().ToList();
            UserList = service.GetAllUsers().ToList();
        }

        /// <summary>
        /// Constructor with edit admin window opening
        /// </summary>
        /// <param name="addAdminOpen">opens the edit admin window</param>
        /// <param name="adminEdit">gets the admin info that is being edited</param>
        public AddUserViewModel(AddAdmin addAdminOpen, vwAdmin adminEdit)
        {
            admin = adminEdit;
            addAdmin = addAdminOpen;
            AllInfoAdminList = service.GetAllAdminsInfo().ToList();
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

        /// <summary>
        /// Specific Admin
        /// </summary>
        private vwAdmin admin;
        public vwAdmin Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        /// <summary>
        /// Cheks if its possible to execute the add and edit employee commands
        /// </summary>
        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }

        /// <summary>
        /// Checks if its possible to execute the add and edit manager commands
        /// </summary>
        public static bool IsUpdateManager = false;

        /// <summary>
        /// Cheks if its possible to execute the add and edit admin commands
        /// </summary>
        private bool isUpdateAdmin;
        public bool IsUpdateAdmin
        {
            get
            {
                return isUpdateAdmin;
            }
            set
            {
                isUpdateAdmin = value;
            }
        }

        /// <summary>
        /// Get selected Sector
        /// </summary>
        private tblSector sector;
        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }

        /// <summary>
        /// Get selected Position
        /// </summary>
        private tblPosition position;
        public tblPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        /// <summary>
        /// List of all positions in the application
        /// </summary>
        private List<tblPosition> positionList;
        public List<tblPosition> PositionList
        {
            get
            {
                return positionList;
            }
            set
            {
                positionList = value;
                OnPropertyChanged("PositionList");
            }
        }

        /// <summary>
        /// List of all sectors in the application
        /// </summary>
        private List<tblSector> sectorList;
        public List<tblSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command that tries to save the new manager
        /// </summary>
        private ICommand saveManager;
        public ICommand SaveManager
        {
            get
            {
                if (saveManager == null)
                {
                    saveManager = new RelayCommand(param => SaveManagerExecute(), param => this.CanSaveManagerExecute);
                }
                return saveManager;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveManagerExecute()
        {
            try
            {
                service.AddManager(Manager);
                IsUpdateManager = true;

                addManager.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the manager
        /// </summary>
        protected bool CanSaveManagerExecute
        {
            get
            {
                return Manager.IsValid;
            }
        }

        /// <summary>
        /// Command that tries to save the new employee
        /// </summary>
        private ICommand saveEmployee;
        public ICommand SaveEmployee
        {
            get
            {
                if (saveEmployee == null)
                {
                    saveEmployee = new RelayCommand(param => SaveEmployeeExecute(), param => this.CanSaveEmployeeExecute);
                }
                return saveEmployee;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveEmployeeExecute()
        {
            try
            {
                if (Manager != null)
                {
                    Employee.ManagerID = Manager.ManagerID;
                }
                if (Sector != null)
                {
                    Employee.SectorID = Sector.SectorID;
                }               
                if (Position != null)
                {
                    Employee.PositionID = Position.PositionID;
                }               
                service.AddEmployee(Employee);
                IsUpdateEmployee = true;

                addEmployee.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the employee
        /// </summary>
        protected bool CanSaveEmployeeExecute
        {
            get
            {
                return Employee.IsValid;
            }
        }

        /// <summary>
        /// Command that tries to save the new admin
        /// </summary>
        private ICommand saveAdmin;
        public ICommand SaveAdmin
        {
            get
            {
                if (saveAdmin == null)
                {
                    saveAdmin = new RelayCommand(param => SaveAdminExecute(), param => this.CanSaveAdminExecute);
                }
                return saveAdmin;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveAdminExecute()
        {
            try
            {
                service.AddAdmin(Admin);
                IsUpdateAdmin = true;

                addAdmin.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the employee
        /// </summary>
        protected bool CanSaveAdminExecute
        {
            get
            {
                return Admin.IsValid;
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
            try
            {
                if (Application.Current.Windows.OfType<AddEmployee>().FirstOrDefault() != null)
                {
                    addEmployee.Close();
                }
                else if (Application.Current.Windows.OfType<AddManager>().FirstOrDefault() != null)
                {
                    addManager.Close();
                }
                else if (Application.Current.Windows.OfType<AddAdmin>().FirstOrDefault() != null)
                {
                    addAdmin.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to execute the close command
        /// </summary>
        /// <returns>true</returns>
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
