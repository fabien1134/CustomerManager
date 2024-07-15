namespace CustomerManagerAPI.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string SurName { get; set; }
        public required int Age { get; set; }
        public required string Email { get; set; }
        public required DateTime Created { get; set; }
        public required DateTime LastUpdated { get; set; }
    }
}
