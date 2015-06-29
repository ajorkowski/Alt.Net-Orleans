using Orleans;
using System.Threading.Tasks;

namespace OrleansExample.Interfaces.Advanced
{
    public interface ICustomerIndexer : IGrainWithIntegerKey
    {
        Task IndexCustomer(Customer customer);
    }
}
