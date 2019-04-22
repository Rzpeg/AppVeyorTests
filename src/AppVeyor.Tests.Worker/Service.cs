using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppVeyor.Tests.Worker
{
    public class Service
    {
        CancellationTokenSource cts = new CancellationTokenSource(); 

        public void Start()
        {
            Task.Run(Run);
        }

        public void Stop()
        {
            Console.WriteLine("Stopping...");

            this.cts.Cancel();
        }

        private async Task Run()
        {
            while (!this.cts.IsCancellationRequested)
            {
                Console.WriteLine("Running...");

                await Task.Delay(1000)
                    .ConfigureAwait(false);
            }
        }
    }
}
