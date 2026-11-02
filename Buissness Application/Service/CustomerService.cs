using Buissness_Application.Model;
using Buissness_Application.Repositries;
using Buissness_Application.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Buissness_Application.Service
{
    public class CustomerService
    {
        private readonly CustomerRepositries _repositry;
        private List<CustomerModel> CustomerList;
        public CustomerService()
        {
            _repositry = new CustomerRepositries();
            CustomerList = _repositry.GetData();
        }
        public void AddCustomer(CustomerModel customer)
        {
            _repositry.SaveObject(customer);
        }
        public CustomerModel FindCustomer(string Id)
        {
            CustomerModel c = new CustomerModel();
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (CustomerList[i].CustomerId == Id)
                {
                    return c;
                }
            }
            return null;
        }
        public void DeleteCustomer(CustomerModel c)
        {
            CustomerList.Remove(c);
            _repositry.SaveList(CustomerList);
        }
    }
}
