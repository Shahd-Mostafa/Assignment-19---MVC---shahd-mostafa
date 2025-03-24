namespace Assignment_19___MVC___shahd_mostafa.services
{
    public interface IScopedService
    {
        string GetGuid();
    }
    public class ScopedService : IScopedService
    {
        readonly Guid _guid;
        public string GetGuid() => _guid.ToString();
        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }
    }
}
