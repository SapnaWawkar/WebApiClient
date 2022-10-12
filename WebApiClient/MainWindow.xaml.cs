
using Models.D2H.Entities;
using Models.D2H.Operations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WebApiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient httpClient;
        public MainWindow()
        {
            httpClient = new HttpClient();
            InitializeComponent();
            Fill_ListBox();
        }

       
        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            AddCustomer anc=new AddCustomer();
            anc.Visibility= Visibility.Visible;

            /*var result = httpClient.GetAsync($"https://localhost:44318/api/Packages?name={txtSeach.Text}")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Package>>()
                .Result;

            lstbxPackages.ItemsSource = result;*/
        }

        private void Fill_ListBox()
        {
            var result = CustomerOpeartions.GetAllPackages();
            foreach(var package in result)
            {
                Packages.Items.Add(package.Name);
            }
            
        }

        private void GetCustomer(object sender, RoutedEventArgs e)
        {
           
            var result = httpClient.GetAsync($"https://localhost:44318/api/Customer?name={txtCustomerName.Text}")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Customer>>()
                .Result;

            
            lstbxPackages.ItemsSource = result;           
            
        }
    }
}
