using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using Nedeljni_I_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        public AddAdmin()
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this);
        }

        /// <summary>
        /// Window constructor for editing admin
        /// </summary>
        /// <param name="managerEdit">manager that is bing edited</param>
        public AddAdmin(vwAdmin adminEdit)
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this, adminEdit);
        }

        /// <summary>
        /// User can only imput numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
