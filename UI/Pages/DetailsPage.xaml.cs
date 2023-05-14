using DataAccess.Entities;
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
using System.Collections.ObjectModel;
using DataAccess;

namespace HotelManagementSystem.Pages
{
    public partial class DetailsPage : Page
    {

        private AppDbContext _context = new AppDbContext();

        public DetailsPage()
        {
            InitializeComponent();

            // Retrieve Reservation data from database context
            List<Reservation> reservations = _context.Reservations.ToList();

            // Set the ItemsSource of the DataGrid to the reservations list
            ReservationList.ItemsSource = new ObservableCollection<Reservation>(reservations);

            //ReservationList.ItemsSource = reservations;
        }
    }
}
