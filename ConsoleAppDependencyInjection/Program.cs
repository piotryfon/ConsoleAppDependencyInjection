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

            //IBuisness buisness = new Buisness();
            IBuisness buisness = new BuisnessVer2();
            buisness.SignUp(username, password);
        }
    }
    class Buisness : IBuisness
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
    class BuisnessVer2 : IBuisness
    {
        public void SignUp(string username, string password)
        {
            if (username.Length < 3 || password.Length < 3)
            {
                Console.WriteLine("Signup failed, to short username or password...");
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.Store(username, password);
                Console.WriteLine($"You are signup as {username}");
            }
        }
    }
    class DataAccess : IDataAccess
    {
        public void Store(string username, string password)
        {
            Console.WriteLine("Storing in db...");
        }
    }
    interface IDataAccess
    {
       void Store(string username, string password);
    }
    interface IBuisness
    {
        void SignUp(string username, string password);
    }
}
