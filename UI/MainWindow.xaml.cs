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
using HotelManagementSystem.Pages;
using MaterialDesignColors;

namespace HotelManagementSystem
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
           // PagesNavigation.Navigate(new HomePage());
            
            PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdSearch_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/SearchPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdGuestDetails_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/DetailsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdRooms_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/RoomsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWin = new LoginWindow();
            loginWin.Show();
            Close();
        }  
        
        public void ShowKitchenButtons()
        {
            rdHome.Visibility = Visibility.Collapsed;
            rdSearch.Visibility = Visibility.Collapsed;
            rdGuestDetails.Visibility = Visibility.Collapsed;
            rdRooms.Visibility = Visibility.Collapsed;
            rdKitchenTODO.Visibility = Visibility.Visible;
            rdKitchenGuestDetails.Visibility = Visibility.Visible;
        }

        private void rdKitchenGuestDetails_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Kitchen/DetailsPage.xaml", UriKind.RelativeOrAbsolute));

        }

        private void rdKitchenTODO_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Kitchen/TodoPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
