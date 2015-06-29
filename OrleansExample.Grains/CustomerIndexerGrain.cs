using Orleans;
using Orleans.Concurrency;
using Orleans.Runtime;
using OrleansExample.Interfaces.Advanced;
using System.Threading.Tasks;

namespace OrleansExample.Grains.Advanced
{
    [StatelessWorker]
    [Reentrant]
    public class CustomerIndexerGrain : Grain, ICustomerIndexer
    {
        public async Task IndexCustomer(Customer customer)
        {
            // TODO: Send customer to full text engine like Elastic Search/Azure Search
            // or send to table storage (or both)
        }
    }
}
