namespace JwtTokenAPi.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }=string.Empty;
        //Because password should not be stored in Raw format
        public string PasswordHash { get; set; }=string.Empty;
        public string Role { get; set; }
    }
}
