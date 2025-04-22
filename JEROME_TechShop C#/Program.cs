using JEROME_TechShop.dao;

using JEROME_TechShop;
using JEROME_TechShop.Entity;

namespace JEROME_TechShop.main
{
    class MainModule
    {
        static void Main(string[] args)
        {
            ICustomerDAO customerDAO = new TechShopCRUD();
            while (true)
            {
                Console.WriteLine("\n1. Register Customer\n2. Get Customer\n3. Update Customer\n4. Delete Customer\n5. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Customer c = new Customer();
                        Console.Write("First Name: "); c.FirstName = Console.ReadLine();
                        Console.Write("Last Name: "); c.LastName = Console.ReadLine();
                        Console.Write("Email: "); c.Email = Console.ReadLine();
                        Console.Write("Phone: "); c.Phone = Console.ReadLine();
                        Console.Write("Address: "); c.Address = Console.ReadLine();
                        customerDAO.AddCustomer(c);
                        break;
                    case 2:
                        Console.Write("Enter Customer ID: ");
                        var cust = customerDAO.GetCustomerById(Convert.ToInt32(Console.ReadLine()));
                        if (cust != null) cust.GetCustomerDetails();
                        else Console.WriteLine("Customer not found.");
                        break;
                    case 3:
                        Console.Write("Enter ID to update: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var existing = customerDAO.GetCustomerById(id);
                        if (existing != null)
                        {
                            Console.Write("New Email: "); existing.Email = Console.ReadLine();
                            customerDAO.UpdateCustomer(existing);
                        }
                        break;
                    case 4:
                        Console.Write("Enter ID to delete: ");
                        customerDAO.DeleteCustomer(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}
