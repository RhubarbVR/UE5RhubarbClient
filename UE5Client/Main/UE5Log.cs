using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealEngine.Framework;
using RhuEngine;

using REngine = RhuEngine.Engine;
using RhuEngine.Linker;

namespace UERhubarbVR
{
    public class UE5Log : IRLog
    {
        public void Err(string value)
        {
            LogOutput(RhuEngine.Linker.LogLevel.Error, value);
        }

        public void Info(string value)
        {
            LogOutput(RhuEngine.Linker.LogLevel.Info, value);
        }
        public void Warn(string v)
        {
            LogOutput(RhuEngine.Linker.LogLevel.Warning, v);
        }
        public event Action<RhuEngine.Linker.LogLevel, string> Log;
        private string TimeStamp => DateTime.Now.ToLongTimeString();

        public void LogOutput(RhuEngine.Linker.LogLevel logLevel,string log)
        {
            if (string.IsNullOrEmpty(log))
            {
                return;
            }
            var logPreamble = $"[{TimeStamp}:{logLevel}]: ";
            switch (logLevel)
            {
                case RhuEngine.Linker.LogLevel.Diagnostic:
                    Debug.Log(UnrealEngine.Framework.LogLevel.Display, logPreamble + log);
                    break;
                case RhuEngine.Linker.LogLevel.Info:
                    Debug.Log(UnrealEngine.Framework.LogLevel.Display, logPreamble + log);
                    break;
                case RhuEngine.Linker.LogLevel.Warning:
                    Debug.Log(UnrealEngine.Framework.LogLevel.Warning, logPreamble + log);
                    break;
                case RhuEngine.Linker.LogLevel.Error:
                    Debug.Log(UnrealEngine.Framework.LogLevel.Error, logPreamble + log);
                    break;
                default:
                    break;
            }
            Log?.Invoke(logLevel, logPreamble + log);
        }

        public void Subscribe(Action<RhuEngine.Linker.LogLevel, string> logCall)
        {
            Log += logCall;
        }

        public void Unsubscribe(Action<RhuEngine.Linker.LogLevel, string> logCall)
        {
            Log -= logCall;
        }


    }
}
