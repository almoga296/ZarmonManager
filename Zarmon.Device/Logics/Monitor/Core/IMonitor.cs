using System.Threading;
using System.Threading.Tasks;

namespace Zarmon.Device.Logics.Monitor.Core
{
    internal interface IMonitor
    {
        Task StartMonitor(CancellationToken externalCancellationToken);
        void StopMonitor();
    }
}