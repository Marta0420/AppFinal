using Map3Mazo.Google;
using Map3Mazo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Map3Mazo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var main = (MainViewModel)BindingContext;
            if (!string.IsNullOrEmpty(main.Address))
            {
                map.Pins.Clear();
                var location = await googleApi.GetLocation(main.Address);
                var coordinates = location.results.FirstOrDefault().geometry.location;
                var pin = new Pin
                {
                    Position = new Position(coordinates.lat, coordinates.lng),
                    Label = location.results.FirstOrDefault().formatted_address,
                    Type = PinType.SearchResult
                };
                map.Pins.Add(pin);
            }

        }
    }
}
