using Map3Mazo.Google;
using Map3Mazo.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Map3Mazo
{
    public partial class App : Application
    {
        static ApiRepository database;
        //Conexion a la base de datos
        public static ApiRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ApiRepository(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "Negocios.db8"));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage( new RegisterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
