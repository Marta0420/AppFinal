using System;
using System.Collections.Generic;
using System.Text;

namespace Map3Mazo.ViewModels
{
    public class MainViewModel
    {
        public string Address { get; set; }
        public MainViewModel() {
            FillPage();
        }  
        public async void FillPage()
        {
            var myNomb = (App.Current.Properties["nom"].ToString());
            var myDire = (App.Current.Properties["dire"].ToString());

            Address = myDire;
            
        }
    }
}
