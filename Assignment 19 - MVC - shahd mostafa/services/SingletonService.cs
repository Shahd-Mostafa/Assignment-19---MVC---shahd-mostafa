namespace Assignment_19___MVC___shahd_mostafa.services
{
    public interface ISingletonService
    {
        string GetGuid();
    }
    public class SingletonService : ISingletonService
    {
        readonly Guid _guid;
        public string GetGuid() => _guid.ToString();
        public SingletonService()
        {
            _guid = Guid.NewGuid();
        }
    }
}
