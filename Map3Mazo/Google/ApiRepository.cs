using Map3Mazo.Resources;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Map3Mazo.Google
{
    public class ApiRepository
    {
        readonly SQLiteAsyncConnection database;

        public ApiRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //Creando La tabla
            database.CreateTableAsync<PersonModel>().Wait();
            
        }
        ///Metodo Para solicitar los datos para llenar la lista de personas
        public Task<List<PersonModel>> GetPersonsAsync()
        {
            return database.Table<PersonModel>().ToListAsync();
        }


        //Metodo Para solicitar los datos po ID y poderlos modificar 
        public Task<PersonModel> GetPersonAsync(int id)
        {
            return database.Table<PersonModel>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }


        //Metodo para guardar el listado o registro de persona en la base de datos
        public Task<int> SavePersonAsync(PersonModel person)
        {
            if (person.ID != 0)
            {
                return database.UpdateAsync(person);
            }
            else
            {
                return database.InsertAsync(person);
            }
        }
     

        //Para borrar un registro del listado de personas
        public Task<int> DeletePersonAsync(PersonModel person)
        {
            return database.DeleteAsync(person);
        }
       
    }
}
