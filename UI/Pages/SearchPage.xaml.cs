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
using DataAccess;
using DataAccess.Entities;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

namespace HotelManagementSystem.Pages
{

    public partial class SearchPage : Page
    {

        private AppDbContext _context = new AppDbContext();
        private bool isAnimationTriggered = false;


        public SearchPage()
        {
            InitializeComponent();


        }

        private void SearchTermTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (SearchTermTextBox.Text.Length > 0 && !isAnimationTriggered)
            {
                Storyboard moveUpStoryboard = (Storyboard)FindResource("MoveUpStoryboard");
                moveUpStoryboard.Begin();
                isAnimationTriggered = true;
                LoadingIndicator.Visibility = Visibility.Visible;

            }

            if (SearchTermTextBox.Text.Length == 0 && isAnimationTriggered)
            {
                ReservationList.ItemsSource = null;
                ReservationList.Visibility = Visibility.Hidden;
                LoadingIndicator.Visibility = Visibility.Hidden;



                Storyboard MoveDownStoryboard = (Storyboard)FindResource("MoveDownStoryboard");
                MoveDownStoryboard.Begin();
                isAnimationTriggered = false;

            }

        }

        private void MoveUpStoryboard_Completed(object sender, EventArgs e)
        {
            ReservationList.Visibility = Visibility.Visible;
            FillDataGrid();
        }


        private void FillDataGrid()
        {
            string searchQuery = SearchTermTextBox.Text;
            var results = _context.Reservations.Where(x =>  x.FirstName.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.LastName.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.BirthDay.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.Gender.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.PhoneNumber.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.EmailAddress.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.StreetAddress.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.AptSuite.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.City.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.State.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.ZipCode.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.RoomType.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.RoomFloor.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.RoomNumber.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.PaymentType.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.CardType.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.CardNumber.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.CardExp.ToLower().Contains(searchQuery.ToLower()) ||
                                                            x.CardCvc.ToLower().Contains(searchQuery.ToLower())
                                                       ).ToList();

            ReservationList.ItemsSource = results;
        }
    }
}
