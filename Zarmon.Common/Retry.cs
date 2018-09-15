using System;
using Serilog;

namespace Zarmon.Common
{
    public class Retry
    {
        public static void Do(Action originalAction, Action fixHandlerAction, int numberOfRetries=3)
        {
            for (int i = 0; i < numberOfRetries; i++)
            {
                try
                {
                    originalAction();
                    return;
                }
                catch (Exception expection)
                {
                    Log.Warning(expection, "Failed to open connection");
                    fixHandlerAction();
                } 
            }
            Log.Error("Failed to open connection after retry: {times} times", numberOfRetries);
            throw new TimeoutException();
        }

        public static T Do<T>(Func<T> originalAction, Action fixHandlerAction, int numberOfRetries = 3)
        {
            for (int i = 0; i < numberOfRetries; i++)
            {
                try
                {
                    T result = originalAction();
                    return result;
                }
                catch (Exception expection)
                {
                    Log.Warning(expection, "Failed to open connection");
                    fixHandlerAction();
                }
            }
            Log.Error("Failed to open connection after retry: {times} times", numberOfRetries);
            throw new TimeoutException();
        }
    }
}
