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
using static CustomerManager_WPF_SQL.Services.CustomerServiceManager;

namespace CustomerManager_WPF_SQL.Views
{
    /// <summary>
    /// Interaction logic for CreateErrand.xaml
    /// </summary>
    public partial class CreateErrand : UserControl
    {

        private readonly ICustomerService customerService = new CustomerService();

        public CreateErrand()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var email = tbErrandCustomerEmail.Text;

            var _customer = customerService.GetCustomer(email);

            _customer.Errand = new Models.CustomerErrand
            {
                ErrandDescription = tbErrandCustomerEmail.Text,
            };
        }
    }
}
