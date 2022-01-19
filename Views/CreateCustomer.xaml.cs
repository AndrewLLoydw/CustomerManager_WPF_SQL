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
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : UserControl
    {

        private readonly ICustomerService customerservice = new CustomerService();

        public CreateCustomer()
        {
            InitializeComponent();
            ClearTb();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbPhoneNumber.Text) && !string.IsNullOrEmpty(tbStreetAddress.Text) && !string.IsNullOrEmpty(tbPostalCode.Text) && !string.IsNullOrEmpty(tbCity.Text) && !string.IsNullOrEmpty(tbCountry.Text))
            {
                if (customerservice.CreateCustomer(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhoneNumber.Text, tbStreetAddress.Text, tbPostalCode.Text, tbCity.Text, tbCountry.Text))
                    ClearTb();

                else
                    tbCustomerError.Text = "Det finns redan en användare med denna E-postaddress, vänligen försök igen";
            }
        }

        private void ClearTb()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbPhoneNumber.Text = "";
            tbStreetAddress.Text = "";
            tbPostalCode.Text = "";
            tbCity.Text = "";
            tbCountry.Text = "";
        }

    }
}
