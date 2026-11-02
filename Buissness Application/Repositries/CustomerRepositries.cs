using Buissness_Application.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Repositries
{
    public class CustomerRepositries
    {
        private readonly string _CustomerFile = "C:\\BSCS_2nd_Semester\\OOP Programming\\Buissness Project\\Buissness Application\\CustomerRecord.txt";
        public void SaveObject(CustomerModel customer)
        {
            using (StreamWriter write = new StreamWriter(_CustomerFile, true))
            {
                write.WriteLine(customer.ToString());
            }
        }
        public void SaveList(List<CustomerModel> CustomerList)
        {
            ClearData();
            using (StreamWriter write = new StreamWriter(_CustomerFile, true))
            {
                foreach (var i in CustomerList)
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
        public List<CustomerModel> GetData()
        {
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            CustomerModel customer = new CustomerModel();
            StreamReader read = new StreamReader(_CustomerFile);
            string details;
            while ((details = read.ReadLine()) != null)
            {
                customer.CustomerId = GetField(details, 1);
                customer.CustomerName = GetField(details, 2);
                customer.Address = GetField(details, 3);
                customer.ContactNo = GetField(details, 4);
                customer.PostalCode = int.Parse(GetField(details, 5));
                customer.ProductCode = GetField(details, 6);
                customer.ProductPrice = float.Parse(GetField(details, 7));
                CustomerList.Add(new CustomerModel(customer.CustomerId, customer.CustomerName, customer.Address, customer.ContactNo, customer.PostalCode, customer.ProductCode, customer.ProductPrice));
            }
            read.Close();
            return CustomerList;
        }
        public void ClearData()
        {
            File.WriteAllText(_CustomerFile, string.Empty);
        }
    }
}