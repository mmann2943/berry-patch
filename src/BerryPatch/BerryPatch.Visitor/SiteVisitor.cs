namespace BerryPatch.Visitor
{
    public interface SiteVisitor
    {
        bool IsLoggedIn { get; }
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
        string Password { get; }
    }
}