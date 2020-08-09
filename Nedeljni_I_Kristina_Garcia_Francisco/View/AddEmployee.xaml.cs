using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using Nedeljni_I_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_I_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this);
        }

        /// <summary>
        /// Window constructor for editing employee
        /// </summary>
        /// <param name="employeeEdit">employee that is bing edited</param>
        public AddEmployee(vwEmployee employeeEdit)
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this, employeeEdit);
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
