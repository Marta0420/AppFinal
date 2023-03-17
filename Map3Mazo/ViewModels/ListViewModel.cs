using Map3Mazo.Resources;
using Map3Mazo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Map3Mazo.ViewModels
{
    public class ListViewModel
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

        //public ICommand Delete => new Command(DeleteGood);
        public ICommand Search => new Command(SearchPerson);
        public PersonModel SelectPerson { get; set; }
        public ObservableCollection<PersonModel> PersonList { get; set; }

        //Metodo para eliminar un registro seleccionado de la lista
        //public async void DeleteGood()
        //{
        //    if (SelectGood != null)
        //    {
        //        var res = await App.Current.MainPage.DisplayAlert("Alerta", "Desea eliminar el registro seleccionado", "si", "no");
        //        if (res)
        //        {
        //            var del = App.Database.DeleteGoodAsync(SelectGood);
        //            await App.Current.MainPage.DisplayAlert("Alerta", "El registro ha sido eliminado con exito", "ok");
        //            await App.Current.MainPage.Navigation.PushAsync(new GoodList());
        //        }
        //        else
        //        {
        //            await App.Current.MainPage.DisplayAlert("Alerta", "El registro no ha sido eliminado", "ok");
        //            await App.Current.MainPage.Navigation.PushAsync(new GoodList());
        //        }

        //    }
        //    else
        //    {
        //        await App.Current.MainPage.DisplayAlert("Alerta", "Seleccione el registro que de sea eliminar", "ok");
        //    }
        //}
        //Método para editar o actualizar un registro de la lista
        public async void SearchPerson()
        {
            if (SelectPerson != null)
            {
                App.Current.Properties["id"] = SelectPerson.ID;
                App.Current.Properties["nom"] = SelectPerson.Nombre;
                App.Current.Properties["dire"] = SelectPerson.Direccion;
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());


            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Seleccione el " +
                    "registro que de sea modificar", "ok");
            }
        }

        //Metodo para llenar la lista de la página
        public ListViewModel()
        {
            FillList();
        }
        private async void FillList()
        {
            PersonList = new ObservableCollection<PersonModel>();
            var MyList = await App.Database.GetPersonsAsync();
            foreach (var item in MyList)
            {
                PersonList.Add(new PersonModel
                {
                    ID = item.ID,
                    Nombre = item.Nombre,
                    Direccion = item.Direccion,
                });
            }
        }
    }
}
