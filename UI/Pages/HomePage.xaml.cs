using DataAccess;
using DataAccess.Entities;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Reflection;
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
using static HotelManagementSystem.Pages.PaymentPage;
using System.ComponentModel;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging.Abstractions;

namespace HotelManagementSystem.Pages
{

    public partial class HomePage : Page
    {
        private AppDbContext _context = new AppDbContext();
        public event PropertyChangedEventHandler PropertyChanged;

        int[] foodSelection = new int[3];
        bool[] specialNeeds = new bool[3];
        string[] paymentInfo = new string[4];
        double totalBill;
        int? selectedId = null;
        Reservation reservation;
        PaymentPage paymentPage = new PaymentPage();
        FoodMenuPage foodmenu = new FoodMenuPage();


        private readonly Dictionary<string, string> roomFloor = new(){
                {"Single","1"},
                {"Double","2"},
                {"Twin","3"},
                {"Duplex","4"},
                {"Suite","5"}};


        private readonly Dictionary<string, int> roomPrices = new(){
                {"Single",149},
                {"Double",299},
                {"Twin",349},
                {"Duplex",399},
                {"Suite",499}};


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


            if (selectedId != null)
            {
                // Update existing reservation
                reservation = _context.Reservations.Find(selectedId);
                if (reservation == null)
                {
                    MessageBox.Show("Reservation not found");
                    return;
                }
            }
            else
            {
                // Add new reservation
                reservation = new Reservation();
                _context.Reservations.Add(reservation);
            }

            reservation.FirstName = firstName.Text;
            reservation.LastName = lastName.Text;
            reservation.BirthDay = birthdate.Text;
            reservation.Gender = gender.Text;
            reservation.PhoneNumber = phone.Text;
            reservation.EmailAddress = email.Text;
            reservation.StreetAddress = stAddress.Text;
            reservation.AptSuite = apartment.Text;
            reservation.City = city.Text;
            reservation.State = governorate.Text;
            reservation.ZipCode = zipCode.Text;
            reservation.RoomFloor = FloorNumComboBox.Text;
            reservation.RoomNumber = roomNum.Text;
            reservation.NumberGuest = Convert.ToInt32(guestNum.Text);
            reservation.RoomType = RoomTypeComboBox.Text;
            reservation.ArrivalTime = Convert.ToDateTime(arrivalDate.Text);
            reservation.LeavingTime = Convert.ToDateTime(leavingDate.Text);
            reservation.CheckIn = checkin.IsChecked;
            reservation.SupplyStatus = FoodSupply.IsChecked;
            reservation.BreakFast = foodSelection[0];
            reservation.Dinner = foodSelection[1];
            reservation.Lunch = foodSelection[2];
            reservation.Cleaning = specialNeeds[0];
            reservation.Towel = specialNeeds[1];
            reservation.SSurprise = specialNeeds[2];
            reservation.TotalBill = totalBill;
            reservation.FoodBill = CalculateFoodBill();
            reservation.PaymentType = paymentInfo[0];
            reservation.CardNumber = paymentInfo[1];
            reservation.CardExp = paymentInfo[2];
            reservation.CardCvc = paymentInfo[3];

            _context.SaveChanges();
            selectedId = null;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectedId != null)
            {
                reservation = _context.Reservations.Find(selectedId);
                foodmenu.BreakfastCheckbox.IsChecked = reservation.BreakFast==0? false :true;
                foodmenu.breakfastTxt.Text = reservation.BreakFast.ToString();

                foodmenu.dinnerCheckbox.IsChecked = reservation.Dinner==0? false :true;
                foodmenu.dinnerTxt.Text = reservation.Dinner.ToString();


                foodmenu.LunchCheckbox.IsChecked = reservation.Lunch == 0 ? false : true;
                foodmenu.lunchTxt.Text = reservation.Lunch.ToString();

                foodmenu.CleaningCheckbox.IsChecked = reservation.Cleaning;
                foodmenu.TowelsCheckbox.IsChecked = reservation.Towel;
                foodmenu.SSurpriseCheckbox.IsChecked = reservation.SSurprise;



              

            }

            foodmenu.FoodMenuDataReturned += FoodmenuData_Returned;
            foodmenu.Show();

        }


        private void FoodmenuData_Returned(object sender, FoodMenuDataEventArgs e)
        {
             foodSelection = e.FoodSelection;
             specialNeeds = e.SpecialNeeds;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedId != null)
            {
                reservation = _context.Reservations.Find(selectedId);
                paymentPage.FillTextBoxes(CalculateRoomBill(), reservation.FoodBill??0);


                paymentPage.PaymentType.Text = reservation.PaymentType;
                paymentPage.cardNum.Text = reservation.CardNumber;
                paymentPage.cvc.Text = reservation.CardCvc;

                paymentPage.expMonth.Text = reservation.CardExp?.Split('/')[0];
                paymentPage.expYear.Text = reservation.CardExp?.Split('/')[1];




            }
            else
            {
                paymentPage.FillTextBoxes(CalculateRoomBill(), CalculateFoodBill());
            }

            paymentPage.PaymentDataReturned += PaymentData_Returned;

            paymentPage.Show();
        }


        private void PaymentData_Returned(object sender, PaymentDataEventArgs e)
        {
            paymentInfo = e.PaymentInfo;
            totalBill = e.TotalBill;
        }

        private void UpdateFloorNumComboBox(object sender, RoutedEventArgs e)
        {
            FloorNumComboBox.Text = roomFloor[((ComboBoxItem)RoomTypeComboBox.SelectedItem).Content.ToString().Trim()];
        }

        private void UpdateRoomTypeComboBox(object sender, SelectionChangedEventArgs e)
        {
            Dictionary<string, string> reversedDic = roomFloor.ToDictionary(x => x.Value, x => x.Key);
            RoomTypeComboBox.Text = reversedDic[((ComboBoxItem)FloorNumComboBox.SelectedItem).Content.ToString().Trim()];
        }

        private void LoadControllers(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem =(string) ReservationComboBox.SelectedItem;
            if (selectedItem != null)
            {

            selectedId = int.Parse(selectedItem.Split('|')[0].Trim());
            var x = _context.Reservations.FirstOrDefault(r => r.Id == selectedId);
            firstName.Text = x.FirstName;
            lastName.Text = x.LastName;
            birthdate.Text = x.BirthDay;
            gender.Text = x.Gender;
            phone.Text = x.PhoneNumber;
            email.Text = x.EmailAddress;
            stAddress.Text = x.StreetAddress;
            apartment.Text = x.AptSuite;
            city.Text = x.City;
            governorate.Text = x.State;
            zipCode.Text = x.ZipCode;
            FloorNumComboBox.Text = x.RoomFloor;
            roomNum.Text = x.RoomNumber;
            guestNum.Text = (x.NumberGuest).ToString();
            RoomTypeComboBox.Text = x.RoomType;
            arrivalDate.Text = x.ArrivalTime.ToString();
            leavingDate.Text = x.LeavingTime.ToString();
            checkin.IsChecked = x.CheckIn;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != null)
            {
                var x = _context.Reservations.Find(selectedId);
                 _context.Reservations.Remove(x);
                 _context.SaveChanges();
                MessageBox.Show("DELETED");
                ReservationComboBox.Items.Refresh();
                PopulateReservationComboBox();
            }

        }


        private int CalculateRoomBill()
        {
            int guestNumber = int.Parse(guestNum.Text);
            int extraGuestFee = guestNumber >= 3 ? guestNumber*5 : 0;
            int RoomFee = roomPrices[((ComboBoxItem)RoomTypeComboBox.SelectedItem).Content.ToString().Trim()];
            int RoomBill = RoomFee + extraGuestFee;
            return RoomBill;

        }   
        
        private int CalculateFoodBill()
        {
            int BreakfastCost = foodSelection[0]*7;
            int DinnerCost = foodSelection[1]*15;
            int LunchCost = foodSelection[2]*15;

            int FoodBill = BreakfastCost + DinnerCost + LunchCost;

          
            return FoodBill;

        }

        private void ClearEverything(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }
    }
}
