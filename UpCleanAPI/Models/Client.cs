namespace UpCleanAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CPF { get; set; }
        public int IdAddress { get; set; }
        public Address Address { get; set; }
        public List<Request> Requests { get; set; }

    }
}
