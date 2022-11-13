namespace Encryption.Data.Models
{
    /// <summary>
    /// Model used to map to table, part of the EF Core data library
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
