using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_10_FINAL.domain
{
    class File
    {
        private string idFile;
        private Person person; //Porque va a recibir una "persona completa (con Du, nombre, apellido...)

        public string IdFile
        {
            get
            {
                return idFile;
            }

            set
            {
                idFile = value;
            }

        }

        public Person Person
        {
            get
            {
                return person;
            }

            set
            {
                person = value;
            }

        }


        public void toString() //Muestro por pantalla lo cargado.
        {
            Console.WriteLine("Id del legajo: {0}\n", IdFile);
            Console.WriteLine("Codigo de la persona : {0}\n", Person.CodePerson);
        }


    }
}
