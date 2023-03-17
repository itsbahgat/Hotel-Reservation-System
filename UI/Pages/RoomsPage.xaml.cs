using DataAccess;
using DataAccess.Entities;
﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagementSystem.Pages
{

    public partial class RoomsPage : Page
    {
        private AppDbContext _context = new AppDbContext();

        public RoomsPage()
        {
            InitializeComponent();
            FillOccupiedRoomsList();
            FillReservedRoomsList();


        }

        public void FillOccupiedRoomsList()
        {

            List<Reservation> reservations = _context.Reservations
                          .Where(r => r.CheckIn == false)
                          .Select(s => new Reservation
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              PhoneNumber = s.PhoneNumber,
                              RoomType = s.RoomType,
                              RoomNumber = s.RoomNumber,
                          })
                          .ToList();
            OccupiedRoomsList.ItemsSource = new ObservableCollection<Reservation>(reservations);

        }
        public void FillReservedRoomsList()
        {

            List<Reservation> reservations = _context.Reservations
                .Where(r => r.CheckIn == true)
                .Select(s => new Reservation
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    PhoneNumber = s.PhoneNumber,
                    RoomType = s.RoomType,
                    RoomNumber = s.RoomNumber,
                    ArrivalTime = s.ArrivalTime.Date,
                    LeavingTime = s.LeavingTime.Date,
                })
                .ToList();

            ReservedRoomsList.ItemsSource = new ObservableCollection<Reservation>(reservations);







    }


    }
}
