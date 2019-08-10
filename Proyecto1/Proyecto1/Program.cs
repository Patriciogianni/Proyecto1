
using Proyecto_10_FINAL.domain; // Llamar el paquete siempre 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_10_FINAL
{
    class Program
    {
        static void printWelcomeMessage()
        {
            Console.WriteLine("BIENVENIDO AL SISTEMA DE ADMINISTRACION DE PERSONAL SCALA RH CONSULTING");
            Console.WriteLine(" ");
            Console.WriteLine("Se detecta que no tiene un usuario activo en la aplicacion, debe generarlo para realizar una operacion");
            Console.WriteLine(" ");
        }
        static User firstLogin()
        {
            User user = new User();

            Console.WriteLine("Escriba el nombre de usuario");
            user.Name = Console.ReadLine();
            Console.WriteLine("Escriba su contraseña");
            user.Password = Console.ReadLine();

            return user;
        }

        static void Main(string[] args)
        {
            printWelcomeMessage();
            firstLogin();

            Menu menu = new Menu();
            menu.showMenu();

        }
    }
}