using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Model
{
    public class UserModel
    {
        public string Username;
        public string Password;
        public string Role;
        public UserModel() { }
        public UserModel(string Username, string Password, string Role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
        }
        public override string ToString()
        {
            return Username + "," + Password + "," + Role;
        }
    }
}
