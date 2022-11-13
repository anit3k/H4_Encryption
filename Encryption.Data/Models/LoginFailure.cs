namespace Encryption.Data.Models
{
    /// <summary>
    /// Model used to map to table, part of the EF Core data library
    /// </summary>
    public class LoginFailure
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
    }
}
