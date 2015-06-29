using Orleans;
using Orleans.Runtime;
using OrleansExample.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrleansExample.Grains
{
    public class CustomerIndexerOptimizer : Grain, ICustomerIndexerOptimizer
    {
        private IDisposable _timer;

        public async Task Run()
        {
            if (_timer == null)
            {
                _timer = this.RegisterTimer(RunOptimizer, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(20));
                await this.RegisterOrUpdateReminder("Optimizer_Timer", TimeSpan.FromHours(1), TimeSpan.FromHours(1));
            }
        }

        public async Task Stop()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
                var reminder = await this.GetReminder("Optimizer_Timer");
                await this.UnregisterReminder(reminder);
            }
        }

        public Task ReceiveReminder(string reminderName, TickStatus status)
        {
            if (_timer == null)
            {
                _timer = this.RegisterTimer(RunOptimizer, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(20));
            }
            return TaskDone.Done;
        }

        private async Task RunOptimizer(object state)
        {
            // TODO: Run a task to optimize the search index
        }
    }
}
