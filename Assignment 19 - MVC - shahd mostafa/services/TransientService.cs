namespace Assignment_19___MVC___shahd_mostafa.services
{
    public interface ITransientService
    {
        string GetGuid();
    }
    public class TransientService : ITransientService
    {
        readonly Guid _guid;
        public string GetGuid() => _guid.ToString();
        public TransientService()
        {
            _guid = Guid.NewGuid();
        }
    }
}
