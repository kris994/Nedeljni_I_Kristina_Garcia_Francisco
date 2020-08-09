using Nedeljni_I_Kristina_Garcia_Francisco.Commands;
using Nedeljni_I_Kristina_Garcia_Francisco.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.ViewModel
{
    class ManagerViewModel : BaseViewModel
    {
        ManagerWindow manWindow;

        #region Constructor
        /// <summary>
        /// Constructor with manager param
        /// </summary>
        /// <param name="ManagerWindow">opens the manager window</param>
        public ManagerViewModel(ManagerWindow managerOpen)
        {
            manWindow = managerOpen;
        }
        #endregion

        #region Commands
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
                manWindow.Close();
                login.Show();
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
