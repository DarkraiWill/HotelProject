using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace UP2.Pages
{
    public partial class AddBookingWindow : Window
    {
        Booking _currentbooking;
        HotelEntities HE = HotelEntities.GetContext();

        public event Action<Booking> OnBookingAdded;

        public AddBookingWindow()
        {
            _currentbooking = new Booking();
            Initialize();
        }

        public AddBookingWindow(Booking booking)
        {
            _currentbooking = booking;
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            _currentbooking.CheckInDate = DateTime.Now;
            _currentbooking.CheckOutDate = DateTime.Now;
            DataContext = _currentbooking;
            var List = HE.Guests.ToList();
            List.Reverse();
            ClientsList.ItemsSource = List;
            RoomsList.ItemsSource = HE.Rooms.ToList();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsList.SelectedIndex == -1 ||
                RoomsList.SelectedIndex == -1 ||
                CheckInDatePicker.SelectedDate < DateTime.Now||
                CheckOutDatePicker.SelectedDate <= CheckInDatePicker.SelectedDate)
            {
                MessageBox.Show("Неверный формат даты или не заполнены все поля");
                return;
            }
            HE.Bookings.Add(_currentbooking);
            HE.SaveChanges();
            MessageBox.Show("Информация сохранена!");
            OnBookingAdded.Invoke(_currentbooking);
            Close();
        }
    }
}
