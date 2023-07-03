namespace AwesomeShop.Services.Orders.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public Customer(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
