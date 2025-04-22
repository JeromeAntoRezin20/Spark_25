using JEROME_TechShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEROME_TechShop
{
    public interface ICustomerDAO
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
