using Nedeljni_I_Kristina_Garcia_Francisco.ViewModel;
using System.Windows;

namespace Nedeljni_I_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this);
        }
    }
}
