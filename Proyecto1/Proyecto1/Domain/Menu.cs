using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_10_FINAL.domain
{
    class Menu
    {
        private int opcion;

        static Person createPerson()
        {
            Person person = new Person();

            Console.WriteLine("Escribe el DU");
            person.Du = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Escribe el genero: M / F / Delfin / No sabe");
            person.Gender = Console.ReadLine();


            Console.WriteLine("Escribe el apellido");
            person.LastName = Console.ReadLine();


            Console.WriteLine("Escribe el Nombre completo");
            person.Name = Console.ReadLine();

            Console.WriteLine("Escribe la Edad");
            person.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Escriba la fecha de nacimiento con formato: dia/mes/año");
            person.DateBirth = Console.ReadLine();

            person.CodePerson = generateCodePerson().ToString("00000");

            person.toString(); // Me muestra la persona completa para verificar que este bien cargado.

            return person;
        }

        static int generateCodePerson()
        {
            int code;
            Random random = new Random();
            code = random.Next(100, 1000);
            return code;
        }

        static int generateId(/*List<File> list*/) // Generar el Id del legajo.
        {
            int code;
            Random random = new Random();
            code = random.Next(1, 99);
            return code;
            //string listSize = list.Count().ToString(); // La cantidad de posiciones pasados a string para que la consola lo pueda leer.
            //return "PG 000/" + listSize;
        }
        static File createFile(List<Person> personList, string idfile) // Recibe la lista de personas y el codigo cargado a la persona
        {

            File file = new File();
            file.IdFile = idfile; // el codigo de la persona ingresado sera el codigo del legajo.
            Console.WriteLine("Ingrese el codigo de la persona");
            string code = Console.ReadLine();
            file.Person = personList.Find(p => code.Equals(p.CodePerson)); // Recorre la lista y encuentra una persona donde la condicion de que el codigo y el Id sean iguales, para luego mostrarlo.
                                                                           // la clase file tiene como atributo a Person (persona)

            file.toString();//Lo mostramos.

            return file;
        }


        //static DefinitivePerson asociar(Person p, File f)
        //{
        //    DefinitivePerson person1 = new DefinitivePerson();

        //    person1.PersonDef.Du = p.Du;
        //    person1.PersonDef.Gender = p.Gender;
        //    person1.PersonDef.LastName = p.LastName;
        //    person1.PersonDef.Name = p.Name;
        //    person1.PersonDef.Age = p.Age;
        //    person1.PersonDef.DateBirth = p.DateBirth;
        //    person1.PersonDef.CodePerson = p.CodePerson;
        //    person1.FileDef.IdFile = f.IdFile;

        //    return person1;
        //}

        //static void showPersonList(List<DefinitivePerson> defList)
        //{
        //    foreach (DefinitivePerson p in defList)
        //    {
        //        Console.WriteLine(p.FileDef.IdFile + p.PersonDef.Du + p.PersonDef.LastName + ", " + p.PersonDef.Name);
        //    }
        //}

        static void fileandPersonLists(List<Person> personList, List<File> fileList)
        {
            Console.WriteLine("Lista de Personas");
            Console.WriteLine(" ");
            foreach (Person p in personList)
            {
                Console.WriteLine(/*p.FileID +*/ p.CodePerson + " " + p.Du + " " + p.LastName + ", " + p.Name);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Lista de Legajos");
            Console.WriteLine(" ");
            foreach (File f in fileList)
            {
                Console.WriteLine(f.IdFile);
            }
        }

        public void showMenu()
        {
            List<Person> personList = new List<Person>();
            List<File> fileList = new List<File>();
            //List<DefinitivePerson> defList = new List<DefinitivePerson>();

            do
            {
                do
                {
                    Console.WriteLine("Elija una opción para operar");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("0.- Crear persona");
                    Console.WriteLine("1.- Agregar legajo a la persona");
                    Console.WriteLine("2.- Eliminar Legajo");
                    Console.WriteLine("3.- Modificar Legajo");
                    Console.WriteLine("4.- Legajo Administrador");
                    Console.WriteLine("5.- SALIR");
                    Console.WriteLine("----------------------------------");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion < 0 || opcion > 5)
                    {
                        Console.WriteLine("Ingrese una opcion valida entre 0 y 5");
                    }

                } while (opcion < 0 || opcion > 5);

                switch (opcion)
                {
                    case 0:

                        Person person = createPerson();
                        personList.Add(person); // Se crea la persona y se agrega a la lista de personas.


                        //DefinitivePerson person10 = asociar(person, file);
                        //defList.Add(person10);


                        break;

                    case 1:

                        // Creo el legajo con una persona y su Id lista generado.
                        File file = createFile(personList, generateId().ToString("PG 000/00"));

                        // Agrego el legajo a la lista de legajos.
                        fileList.Add(file);



                        break;

                    case 2:

                        Console.WriteLine("Ingrese el Codigo de la persona que desea eliminar");
                        string codeRemoved = Console.ReadLine();
                        personList.RemoveAll(r => r.CodePerson == codeRemoved);
                        Console.WriteLine("Ingrese el Legajo de la persona que desea eliminar");
                        string fileRemoved = Console.ReadLine();
                        fileList.RemoveAll(f => f.IdFile == fileRemoved);
                        Console.WriteLine("La persona se ha eliminado con exito");
                        break;

                    case 4:
                        //showPersonList(defList);
                        fileandPersonLists(personList, fileList);
                        break;

                    case 5:

                        //userIsOnline = false;
                        break;

                }

            } while (opcion != 5);

            Console.WriteLine("Muchas gracias Vuelva Prontos");

        }

    }
}
