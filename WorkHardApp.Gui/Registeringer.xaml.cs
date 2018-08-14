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
using System.Windows.Shapes;
using WorkHardApp.Entities;
using WorkHardApp.DataAccess;

namespace WorkHardApp.Gui
{
    /// <summary>
    /// Interaction logic for Registeringer.xaml
    /// </summary>
    public partial class Registeringer : Window
    {
        private Repository dbHandler;
        public Registeringer()
        {
            InitializeComponent();
            dbHandler = new Repository();
        }

        private void ButtonEndSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void ButtonSearchNow_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = (DateTime)DatePickerStartDate.SelectedDate;
            DateTime endDate = (DateTime)DatePickerEndDate.SelectedDate;
            List<CheckIn> checkings = dbHandler.GetCheckInsBetweenDates(startDate, endDate);

            foreach (var employee in checkings)
            {
                employee.Employee.FirstName;
            }
        }
    }
}
