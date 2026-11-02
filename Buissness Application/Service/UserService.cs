using Buissness_Application.Model;
using Buissness_Application.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Service
{
    public class UserService
    {
        private readonly UserRepositries _repositry;
        private List<UserModel> UserList;
        public UserService()
        {
            _repositry = new UserRepositries();
            UserList = _repositry.GetData();
        }
        public void AddUserService(UserModel user)
        {
            _repositry.SaveObject(user);
            UserList = _repositry.GetData();
            UserList.Add(user);
        }
        public List<UserModel> GetUser()
        {
            return UserList = _repositry.GetData();
        }
        public string FindUser(string u, string p)
        {
            foreach (var i in UserList)
            {
                if (i.Username == u && i.Password == p)
                {
                    return i.Role;
                }
            }
            return null;
        }
    }
}
