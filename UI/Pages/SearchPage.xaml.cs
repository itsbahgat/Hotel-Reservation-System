using DataAccess;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            if (SearchTermTextBox.Text.Length > 0 )
            {

                if (!isAnimationTriggered)
                {
                    Storyboard moveUpStoryboard = (Storyboard)FindResource("MoveUpStoryboard");
                    moveUpStoryboard.Begin();
                    isAnimationTriggered = true;
                    LoadingIndicator.Visibility = Visibility.Visible;

                }
                else
                    FillDataGrid(SearchTermTextBox.Text.ToLower());

            }

            if (SearchTermTextBox.Text.Length == 0 && isAnimationTriggered)
            {
                ReservationList.ItemsSource = null;
                ReservationList.Visibility = Visibility.Hidden;
                LoadingIndicator.Visibility = Visibility.Collapsed;



                Storyboard MoveDownStoryboard = (Storyboard)FindResource("MoveDownStoryboard");
                MoveDownStoryboard.Begin();
                isAnimationTriggered = false;

            }

        }

        private void MoveUpStoryboard_Completed(object sender, EventArgs e)
        {
            ReservationList.Visibility = Visibility.Visible;
            FillDataGrid(SearchTermTextBox.Text.ToLower());
        }


        private void FillDataGrid(string searchQuery)
        {
            var results = _context.Reservations.Where(x =>
                                                        x.FirstName.ToLower().Contains(searchQuery) ||
                                                        x.LastName.ToLower().Contains(searchQuery) ||
                                                        x.BirthDay.ToLower().Contains(searchQuery) ||
                                                        x.Gender.ToLower().Contains(searchQuery) ||
                                                        x.PhoneNumber.ToLower().Contains(searchQuery) ||
                                                        x.EmailAddress.ToLower().Contains(searchQuery) ||
                                                        x.StreetAddress.ToLower().Contains(searchQuery) ||
                                                        x.AptSuite.ToLower().Contains(searchQuery) ||
                                                        x.City.ToLower().Contains(searchQuery) ||
                                                        x.State.ToLower().Contains(searchQuery) ||
                                                        x.ZipCode.ToLower().Contains(searchQuery) ||
                                                        x.RoomType.ToLower().Contains(searchQuery) ||
                                                        x.RoomFloor.ToLower().Contains(searchQuery) ||
                                                        x.RoomNumber.ToLower().Contains(searchQuery) ||
                                                        x.PaymentType.ToLower().Contains(searchQuery) ||
                                                        x.CardType.ToLower().Contains(searchQuery) ||
                                                        x.CardNumber.ToLower().Contains(searchQuery) ||
                                                        x.CardExp.ToLower().Contains(searchQuery) ||
                                                        x.CardCvc.ToLower().Contains(searchQuery)
                                                    ).ToList();

            ReservationList.ItemsSource = results;
            ReservationList.Visibility = Visibility.Visible;
        }

    }
}
