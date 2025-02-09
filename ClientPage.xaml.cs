
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace UP2.Pages
{
    public partial class ClientPage : Page
    {
        HotelEntities HE = HotelEntities.GetContext();
        List<Guest> ClientsList;
        public ClientPage()
        {
            InitializeComponent();
            ClientsList = HE.Guests.ToList();
            
            DGridClients.ItemsSource = ClientsList;
        }

    }
}
