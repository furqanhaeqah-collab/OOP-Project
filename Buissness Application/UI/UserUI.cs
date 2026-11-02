using Buissness_Application.Model;
using Buissness_Application.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.UI
{
    public class UserUI
    {
        private readonly UserService _service;
        private List<UserModel> UserList;
        public UserUI()
        {
            _service = new UserService();
            UserList = _service.GetUser();
        }
        public void MainHeaderUI()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to M & S Brand Management System ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        public string MainMenuUI()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("--------------- M & S Brand Management System --------------");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.Customer");
            Console.WriteLine("3.Exit");
            Console.Write("Enter your choice: ");
            string mainOption = Console.ReadLine();
            return mainOption;
        }
        public string OwnerMenuUI()
        {
            MainHeaderUI();
            Console.WriteLine("----Owner Menu----");
            Console.WriteLine("Owner Menu");
            Console.WriteLine("1.Add Users");
            Console.WriteLine("2.View Users");
            Console.WriteLine("3.Add Product");
            Console.WriteLine("4.Search Product");
            Console.WriteLine("5.Update Product");
            Console.WriteLine("6.View Product");
            Console.WriteLine("7.Delete Product");
            Console.WriteLine("8.View Customer Feedback");
            Console.WriteLine("9.Search Customer Feedback");
            Console.WriteLine("10.Delete Customer Feedback");
            Console.WriteLine("11.Exit");
            Console.Write("Enter your choice: ");
            string owner_choice = Console.ReadLine();
            return owner_choice;
        }
        public string UserWhoUI()
        {
            MainHeaderUI();
            Console.Write("Enter username: ");
            string u = Console.ReadLine();
            Console.Write("Enter password: ");
            string p = Console.ReadLine();
            string role = _service.FindUser(u,p);
            if(role != null)
            {
                return role;
            }
            else
            {
                return "Invalid Credentials";
            }
        }
        public void AddUserUI(UserModel user)
        {
            Console.WriteLine("---Add a new User---");
            Console.Write("Wnter username: ");
            user.Username = Console.ReadLine();
            Console.Write("Enter password: ");
            user.Password = Console.ReadLine();
            Console.Write("Enter role: ");
            user.Role = Console.ReadLine();
            _service.AddUserService(user);
            Console.WriteLine("User entered successfully in the system");
            Console.ReadKey();
        }
        public void ViewUsersUI()
        {
            Console.WriteLine("Username\tPassword\tRole");
            for(int i = 0; i < UserList.Count; i++)
            {
                Console.WriteLine(UserList[i].Username + "\t\t" + UserList[i].Password + "\t\t" + UserList[i].Role);
            }
            Console.ReadKey();
        }
    }
}
