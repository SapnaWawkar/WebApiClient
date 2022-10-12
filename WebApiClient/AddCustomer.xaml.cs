using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Models.D2H;
using Models.D2H.Entities;

namespace WebApiClient
{
    /// <summary>
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        HttpClient httpClient;
        public AddCustomer()
        {
            httpClient = new HttpClient();
            InitializeComponent();
        }


        private void Addcustomer(object sender, RoutedEventArgs e)
        {
           
            AddNewCustomer cust=new AddNewCustomer();
            cust.FirstName = Firstname.Text;
            cust.LastName = Lastname.Text;
            cust.Username= Username.Text;
            cust.Password= Password.Text;
            cust.ConnectionStatusId = int.Parse(Connectionstatus.Text);
            cust.PackageId=int.Parse(Packageid.Text);
            cust.GroupId = int.Parse(groupid.Text);
            cust.AreaId = int.Parse(Areaid.Text);


            httpClient.PostAsJsonAsync($"https://localhost:44318/api/Customer", cust);
               
        }
    }
}
