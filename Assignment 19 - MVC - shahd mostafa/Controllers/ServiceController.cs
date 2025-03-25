using Assignment_19___MVC___shahd_mostafa.services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class ServiceController : Controller
    {
        readonly ISingletonService _singletonService1;
        readonly ISingletonService _singletonService2;
        readonly IScopedService _scopedService1;
        readonly IScopedService _scopedService2;

        readonly ITransientService _transientService1;
        readonly ITransientService _transientService2;

        public ServiceController(ISingletonService singletonService1, ISingletonService singletonService2, IScopedService scopedService1, IScopedService scopedService2, ITransientService transientService1, ITransientService transientService2)
        {
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }

        public string Index()
        {
            StringBuilder builder= new StringBuilder();
            builder.AppendLine($"Singleton1 => {_singletonService1.GetGuid()}");
            builder.AppendLine($"Singleton2 => {_singletonService2.GetGuid()}");

            builder.AppendLine($"Scoped1 => {_scopedService1.GetGuid()}");
            builder.AppendLine($"Scoped2 => {_scopedService2.GetGuid()}");

            builder.AppendLine($"Transient1 => {_transientService1.GetGuid()}");
            builder.AppendLine($"Transient2 => {_transientService2.GetGuid()}");

            return builder.ToString();
        }

        public string Again()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Singleton1 => {_singletonService1.GetGuid()}");
            builder.AppendLine($"Singleton2 => {_singletonService2.GetGuid()}");

            builder.AppendLine($"Scoped1 => {_scopedService1.GetGuid()}");
            builder.AppendLine($"Scoped2 => {_scopedService2.GetGuid()}");

            builder.AppendLine($"Transient1 => {_transientService1.GetGuid()}");
            builder.AppendLine($"Transient2 => {_transientService2.GetGuid()}");

            return builder.ToString();
        }

        //public int sum(int x,int y)
        //{
        //    return x + y;
        //}
        //public async Task<int> sumAsync(int x ,int y)
        //{
        //    return await Task.Run(() => x + y);
        //}
    }
}
