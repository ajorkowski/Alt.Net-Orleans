using Orleans;
using System;
using System.Threading.Tasks;

namespace OrleansExample.Interfaces.Advanced
{
    public interface ICustomerGrain : IGrainWithGuidKey
    {
        Task SetName(string name);

        Task<Customer> GetModel();
    }

    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
