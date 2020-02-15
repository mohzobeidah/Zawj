namespace JawjAPP.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] Hashpassword { get; set; }
        public byte[] Passwordalt { get; set; }

    }
}