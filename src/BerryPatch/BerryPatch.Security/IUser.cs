namespace BerryPatch.Security
{
    public interface IUser
    {
        string FirstName { get; }
        string LastName { get;}
        string MailingAddress { get;}
        string City { get; }
        string State { get; }
        string Zip { get; }
        string Email { get; }
    }
}