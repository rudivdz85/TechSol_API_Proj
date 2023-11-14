using TechSol_API_Proj.Models;

namespace TechSol_API_Proj.Interfaces
{
    public interface IDatabaseOperations
    {
        void AddCustomer(string firstName, string lastName, DateTime dateOfBirth);
        Customer GetCustomer(int customerId); // Assuming a Customer model exists
        IEnumerable<Customer> GetAllCustomers();
        void UpdateCustomer(int customerId, string firstName, string lastName);
        void DeleteCustomer(int customerId);
    }
}
