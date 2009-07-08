namespace BerryPatch.Repository
{
    public interface RepositoryResult
    {
        bool Success { get;}
        string Message { get; }
    }
}