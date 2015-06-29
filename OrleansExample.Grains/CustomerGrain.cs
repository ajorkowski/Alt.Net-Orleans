using Orleans;
using Orleans.Providers;
using OrleansExample.Interfaces.Advanced;
using System.Threading.Tasks;

namespace OrleansExample.Grains.Advanced
{
    [StorageProvider(ProviderName = "Store")]
    public class CustomerGrain : Grain<ICustomerGrainState>, ICustomerGrain
    {
        // You can override activate/deactivate to do work before the grain starts
        // NOTE: the state is already loaded by the time activate is called
        public override Task OnActivateAsync()
        {
            if (State.Customer == null) 
            {
                State.Customer = new Customer
                {
                    Id = this.GetPrimaryKey(),
                    Name = null
                };
            }

            return TaskDone.Done;
        }

        public async Task SetName(string name)
        {
            State.Customer.Name = name;
            await State.WriteStateAsync();

            // For full effect this call can go via a message queue
            var indexerGrain = GrainFactory.GetGrain<ICustomerIndexer>(0);
            await indexerGrain.IndexCustomer(State.Customer);
        }

        public Task<Customer> GetModel()
        {
            return Task.FromResult(State.Customer);
        }
    }

    public interface ICustomerGrainState : IGrainState
    {
        Customer Customer { get; set; }
    }
}
