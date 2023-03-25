using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HotelManagementSystem.Pages
{

    public partial class HomePage : Page
    {
        private AppDbContext _context = new AppDbContext();
        int[] foodSelection = new int[3];
        bool[] specialNeeds = new bool[3];

        public HomePage()
        {
            InitializeComponent();
            PopulateReservationComboBox();

            roomNum.ItemsSource = new List<string>() { "101", "102", "103", "104", "105", "106", "107", "108", "109", "110",
            "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "301", "302", "303", "304", "305", "306", "307", "308", "309", "310",
            "401", "402", "403", "404", "405", "406", "407", "408", "409", "410", "501", "502", "503", "504", "505", "506", "507", "508", "509", "510"};

        }

        private void PopulateReservationComboBox()
        {

            ReservationComboBox.ItemsSource = _context.Reservations.Select(r => $" {r.Id} | {r.FirstName} {r.LastName} | {r.PhoneNumber}").ToList(); ;

        }

        private void sumbitButton_Click(object sender, RoutedEventArgs e)
        {

            _context.Reservations.Add(new Reservation
            {
                FirstName = firstName.Text,
                                                        LastName = lastName.Text,
                                                        BirthDay = birthdate.Text,
                                                        Gender = gender.Text,
                                                        PhoneNumber = phone.Text,
                                                        EmailAddress = email.Text,
                                                        StreetAddress = stAddress.Text,
                                                        AptSuite = apartment.Text,
                                                        City = city.Text,
                                                        State = governorate.Text,
                                                        ZipCode = zipCode.Text,
                                                        RoomFloor = floorNum.Text,
                                                        RoomNumber = roomNum.Text,
                                                        NumberGuest = Convert.ToInt32(guestNum.Text),
                                                        RoomType = roomType.Text,
                ArrivalTime = Convert.ToDateTime(arrivalDate.Text),
                LeavingTime = Convert.ToDateTime(leavingDate.Text),
                CheckIn = checkin.IsChecked,
                SupplyStatus = FoodSupply.IsChecked,
                BreakFast = foodSelection[0],
                Dinner = foodSelection[1],
                Lunch = foodSelection[2],
                Cleaning = specialNeeds[0],
                Towel = specialNeeds[1],
                SSurprise = specialNeeds[2],
                                                   });

            _context.SaveChanges();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var foodmenu = new FoodMenuPage();

            foodmenu.FoodMenuDataReturned += FoodmenuData_Returned;
            foodmenu.Show();

        }


        private void FoodmenuData_Returned(object sender, FoodMenuDataEventArgs e)
        {
             foodSelection = e.FoodSelection;
             specialNeeds = e.SpecialNeeds;
        }
    }
}
