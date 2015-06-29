using Orleans;
using System.Threading.Tasks;

namespace OrleansExample.Interfaces
{
    public interface ICustomerIndexerOptimizer : IGrainWithIntegerKey, IRemindable
    {
        Task Run();
        Task Stop();
    }
}
