using Buissness_Application.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Repositries
{
    public class UserRepositries
    {
        private readonly string _UserFile = "C:\\BSCS_2nd_Semester\\OOP Programming\\Buissness Project\\Buissness Application\\UserRecord.txt";
        public void SaveObject(UserModel user)
        {
            using (StreamWriter write = new StreamWriter(_UserFile, true))
            {
                write.WriteLine(user.ToString());
            }
        }
        public void SaveList(List<UserModel> UserList)
        {
            ClearData();
            using (StreamWriter write = new StreamWriter(_UserFile))
            {
                foreach (var i in UserList)
                {
                    write.WriteLine(i.ToString());
                }
            }
        }
        public string GetField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }
        public List<UserModel> GetData()
        {
            List<UserModel> UserList = new List<UserModel>();
            UserModel user = new UserModel();
            StreamReader read = new StreamReader(_UserFile);
            string details;
            while ((details = read.ReadLine()) != null)
            {
                user.Username = GetField(details, 1);
                user.Password = GetField(details, 2);
                user.Role = GetField(details, 3);
                UserList.Add(new UserModel(user.Username, user.Password, user.Role));
            }
            read.Close();
            return UserList;
        }
        public void ClearData()
        {
            File.WriteAllText(_UserFile, string.Empty);
        }
    }
}