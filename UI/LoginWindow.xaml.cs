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
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem
{
    public partial class LoginWindow : Window
    {
        bool kitchen = false;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {           
                Application.Current.Shutdown();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
       
                if (isAuthenticatedUser())
                {
                    MainWindow mainWindow = new MainWindow();
                if (kitchen)
                    mainWindow.ShowKitchenButtons();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid login", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            
        }

        private bool isAuthenticatedUser()
        {
            using (var context = new AppDbContext())
            {
                var username = txtUsername.Text;
                var password = txtPassword.Password;
                var login = context.Logins.SingleOrDefault(l => l.username == username && l.password == password);
                if(login !=null && login.username =="kitchen")
                {
                    kitchen = true;
                }
                return login != null;
            }
        }

       
    }
}
