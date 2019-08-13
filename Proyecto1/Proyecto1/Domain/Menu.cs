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

            person.showPerson(); // Me muestra la persona completa para verificar que este bien cargado.

            return person;
        }

        static int generateCodePerson()
        {
            int code;
            Random random = new Random();
            code = random.Next(100, 1000);
            return code;
        }

        static int generateId() // Generar el Id del legajo.
        {
            int code;
            Random random = new Random();
            code = random.Next(1, 99);
            return code;
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
            Console.WriteLine("Se ha generado con éxito el numero de Legajo");

            return file;
        }

        static DefinitivePerson createDefinitivePerson(Person person, File file)
        {
            DefinitivePerson person1 = new DefinitivePerson();
           
            person1.Du = person.Du;
            person1.Gender = person.Gender;
            person1.LastName = person.LastName;
            person1.Name = person.Name;
            person1.Age = person.Age;
            person1.DateBirth = person.DateBirth;
            person1.CodePerson = person.CodePerson;
            person1.FileDef = file.IdFile;

            return person1;
        }

        static void showAllList(List<DefinitivePerson> defList, List<Person> personList, List<File> fileList)
        {
            Console.WriteLine("Lista de Empleados");
            foreach (DefinitivePerson d in defList)
            {
                Console.WriteLine(d.FileDef + " " + d.Du + " " + d.LastName + ", " + d.Name);
            }

            Console.WriteLine("Lista de Personas");
            foreach (Person p in personList)
            {
                Console.WriteLine(p.CodePerson);
            }

            Console.WriteLine("Lista de Legajos");
            foreach  (File f in fileList)
            {
                Console.WriteLine(f.IdFile);
            }

        }

        public void showMenu()
        {
            List<Person> personList = new List<Person>();
            List<File> fileList = new List<File>();
            List<DefinitivePerson> defList = new List<DefinitivePerson>();

            do
            {
                do
                {
                    Console.WriteLine("Elija una opción para operar");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("0.- Crear persona");
                    Console.WriteLine("1.- Eliminar Legajo");
                    Console.WriteLine("2.- Modificar Legajo");
                    Console.WriteLine("3.- Legajo Administrador");
                    Console.WriteLine("4.- SALIR");
                    Console.WriteLine("----------------------------------");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion < 0 || opcion > 5)
                    {
                        Console.WriteLine("Ingrese una opcion valida entre 0 y 5");
                    }

                } while (opcion < 0 || opcion > 4);

                switch (opcion)
                {
                    case 0:

                        // Se crea la persona y se agrega a la lista de personas.
                        Person person = createPerson();
                        personList.Add(person);
                        
                        // Se crea un legajo y se agrega a la lista de legajos.
                        File file = createFile(personList, generateId().ToString("PG000/00"));
                        fileList.Add(file);

                        // Se crea una persona Definitiva y se le agrega la persona y su respectivo ID Legajo.
                        DefinitivePerson person10 = createDefinitivePerson(person, file);
                        defList.Add(person10);
                        break;

                    case 1:

                        Console.WriteLine("Ingrese el codigo de la persona que desea eliminar de forma permanente");
                        string codeRemoved = Console.ReadLine();
                        defList.RemoveAll(r => r.CodePerson == codeRemoved);
                        personList.RemoveAll(r => r.CodePerson == codeRemoved);
                        fileList.RemoveAll(r => r.Person.CodePerson == codeRemoved);
                        Console.WriteLine("La persona se ha eliminado con exito");
                        break;

                    case 3:

                        showAllList(defList, personList, fileList);
                        break;
                }

            } while (opcion != 4);

            Console.WriteLine("Muchas gracias Vuelva Prontos");
        }
    }
}