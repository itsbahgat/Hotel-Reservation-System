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

namespace HotelManagementSystem.Pages.Kitchen
{
    public partial class DetailsPage : Page
    {

        private AppDbContext _context = new AppDbContext();
        

        public DetailsPage()
        {
            InitializeComponent();
            PopulateKitchenOverview();
        }

        private void PopulateKitchenOverview()
        {
            List<Reservation> kitchenOverview = _context.Reservations.Where(r => r.SupplyStatus == false).ToList();
            KitchenOverview.ItemsSource = new ObservableCollection<Reservation>(kitchenOverview);
        }
    }
}
