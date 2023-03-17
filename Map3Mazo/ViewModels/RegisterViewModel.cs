using Map3Mazo.Resources;
using Map3Mazo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Map3Mazo.ViewModels
{
    public class RegisterViewModel
    {
        public ICommand Exit => new Command(ButtonsPage);

        public async void ButtonsPage()
        {
            //nos envía a la pagina de registrar alumnos
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            //nos elimina la pagina anterior del estack de paginas
            var existingPages = App.Current.MainPage.Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(RegisterPage))
                    continue;
                App.Current.MainPage.Navigation.RemovePage(page);
            }

        }
        public ICommand Show => new Command(ShowList);
        public ICommand Save => new Command(SaveRegister);
        public string Name { get; set; }
        public string Address { get; set; }

        public async void ShowList() {
            await App.Current.MainPage.Navigation.PushAsync(new ListPage());
        }
        public async void SaveRegister()
        {
            if (Name != null)
            {
                if (Address != null)
                {
                    var person = new PersonModel()
                    {
                        Nombre = Name,
                        Direccion = Address,
                    };
                    var Sav = await App.Database.SavePersonAsync(person);
                    await App.Current.MainPage.Navigation.PushAsync(new ListPage());
                    if (Sav != null)
                    {
                        await App.Current.MainPage.DisplayAlert("Alerta", "El registro fue guardado con exito", "ok");

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alerta", "El registro no fue guardado", "ok");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "Debe ingrasar datos de precio", "ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Debe ingrasar descripcion para continuar", "ok");
            }

        }
    }
}
