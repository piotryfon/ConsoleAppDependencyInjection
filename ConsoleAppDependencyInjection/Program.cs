using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            userInterface.GetData();

            Console.ReadKey();
        }
    }
    class UserInterface
    {
        public void GetData()
        {
            Console.WriteLine("Enter Username");
            string username =  Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            Buisness buisness = new Buisness();
            buisness.SignUp(username, password);
        }
    }
    class Buisness
    {
        public void SignUp(string username, string password)
        {
            if(username == "" || password == "")
            {
                Console.WriteLine("Signup failed...");
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.Store(username, password);
                Console.WriteLine($"You are signup as {username}");
            }
 
        }
    }
    class DataAccess
    {
        public void Store(string username, string password)
        {
            Console.WriteLine("Storing in db...");
        }
    }
}
