using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Map3Mazo.Resources
{
    public class PersonModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Direccion { get; set; }

    }
}
