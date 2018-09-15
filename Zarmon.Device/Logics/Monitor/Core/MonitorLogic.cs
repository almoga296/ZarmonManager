using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Serilog.Context;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.Logics.Monitor.Core
{
    public abstract class MonitorLogic : Logic, IMonitor
    {
        protected CancellationTokenSource CancellationTokenSource;

        public MonitorSettings MonitorSettings { get; set; }
        public MonitorState MonitorState { get; private set; }
        public event EventHandler<MonitorResult> ErrorEvent;

        #region C'tors

        protected MonitorLogic(MonitorSettings monitorSettings) : base(monitorSettings)
        {
            CancellationTokenSource = new CancellationTokenSource();
            MonitorSettings = monitorSettings;
            MonitorState = MonitorState.Ready;
            Log.Information("Monitor {@Monitor} State: {@MonitorState}", this.GetType().Name, MonitorState);
        }

        protected MonitorLogic(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
            CancellationTokenSource = new CancellationTokenSource();
            MonitorSettings = monitorSettings;
            MonitorState = MonitorState.Ready;
            Log.Information("Monitor {@Monitor} State: {@MonitorState}", this.GetType().Name, MonitorState);
        }

        #endregion

        public Task StartMonitor(CancellationToken externalCancellationToken = default(CancellationToken))
        {
            if (MonitorState == MonitorState.Running)
            {
                Log.Error("Trying to run a running monitor");
                return Task.CompletedTask;
            }
            CancellationTokenSource = new CancellationTokenSource();
            //Link the current cancellation token with the given one, for support external cancellation
            if (externalCancellationToken != default(CancellationToken))
            {
                CancellationTokenSource =
                    CancellationTokenSource.CreateLinkedTokenSource(externalCancellationToken,
                        CancellationTokenSource.Token);
                CancellationTokenSource.Token.Register(UpdateState);
            }

            Prepare();
            MonitorState = MonitorState.Prepared;
            Log.Information("Monitor {@Monitor} State: {@MonitorState}", this.GetType().Name, MonitorState);
            CancellationToken token = CancellationTokenSource.Token;
            return Task.Factory.StartNew(() => 
            {
                MonitorState = MonitorState.Running;
                Log.Information("Monitor {@Monitor} State: {@MonitorState}", this.GetType().Name, MonitorState);
                using (LogContext.PushProperty("MonitorName", this.GetType().Name))
                {
                    while (!CancellationTokenSource.IsCancellationRequested)
                    {
                        MonitorResult monitorResult = Action();
                        Log.Information("-------------  {@monitorResult}  -------------", monitorResult.ResultState);
                        if (monitorResult.ResultState == ResultState.FAIL)
                            OnError(monitorResult);

                        try
                        {
                            Task.Delay(MonitorSettings.SamplingRate, token).Wait();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
            }, token);

        }

        public void StopMonitor()
        {
            Log.Information("{@MonitorName} got cancellation request", this.GetType().Name);
            CancellationTokenSource.Cancel();
        }

        private void UpdateState()
        {
            MonitorState = MonitorState.Canceled;
            Log.Information("Monitor {@Monitor} State: {@MonitorState}", this.GetType().Name, MonitorState);
        }

        protected void Listen(IApi api, EventHandler<DataReceivedEventArgs> callback)
        {
            api.Connection.DataReceived += callback;
        }
        protected void StopListen(IApi api, EventHandler<DataReceivedEventArgs> callback)
        {
            api.Connection.DataReceived -= callback;
        }

        #region Event Handlers

        protected virtual void OnError(MonitorResult monitorResult)
        {
            ErrorEvent?.Invoke(this, monitorResult);
        }

        #endregion

        #region Abstract

        protected abstract void Prepare();
        protected abstract MonitorResult Action();
        protected abstract void Release();

        #endregion
    }
}