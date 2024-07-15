namespace CustomerManagerAPI.Pocos
{
    public class CustomerPoco
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string SurName { get; set; }
        public required int Age { get; set; }
        public required string Email { get; set; }
    }
}
