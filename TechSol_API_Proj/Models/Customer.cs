namespace TechSol_API_Proj.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } // Assuming CustomerID is the primary key in your database
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
