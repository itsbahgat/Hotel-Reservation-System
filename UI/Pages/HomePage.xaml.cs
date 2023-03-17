﻿using System;
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

namespace HotelManagementSystem.Pages
{

    public partial class HomePage : Page
    {
        private AppDbContext _context = new AppDbContext();

        public HomePage()
        {
            InitializeComponent();
        }

        private void sumbitButton_Click(object sender, RoutedEventArgs e)
        {

            _context.Reservations.Add(new Reservation { FirstName = firstName.Text,
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
                                                        ArrivalTime= Convert.ToDateTime(arrivalDate.Text),
                                                        LeavingTime= Convert.ToDateTime(leavingDate.Text),
                                                   });

            _context.SaveChanges();

        }
    }
}
