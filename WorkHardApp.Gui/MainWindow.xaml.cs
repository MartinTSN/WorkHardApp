using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkHardApp.Entities;
using WorkHardApp.DataAccess;

namespace WorkHardApp.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Repository dbHandler;
        public MainWindow()
        {
            InitializeComponent();
            dbHandler = new Repository();
            DataGridEmployees.ItemsSource = dbHandler.GetAllEmployee();
        }

        private void DataGridEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employeeToCheck = DataGridEmployees.SelectedItem as Employee;
            bool checkedIn = dbHandler.CheckIfCheckedIn(employeeToCheck);
            if (checkedIn == true)
            {
                ButtonCheckIn.IsEnabled = false;
                ButtonCheckUd.IsEnabled = true;
            } else
            {
                ButtonCheckIn.IsEnabled = true;
                ButtonCheckUd.IsEnabled = false;
            }
        }

        private void ButtonCheckIn_Click(object sender, RoutedEventArgs e)
        {
            Employee employeeToCheckIn = DataGridEmployees.SelectedItem as Employee;
            dbHandler.CheckIn(employeeToCheckIn);
            LabelCheckInTid.Content = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void ButtonCheckUd_Click(object sender, RoutedEventArgs e)
        {
            Employee employeeToCheckUd = DataGridEmployees.SelectedItem as Employee;
            dbHandler.CheckOut(employeeToCheckUd);
        }
    }
}
