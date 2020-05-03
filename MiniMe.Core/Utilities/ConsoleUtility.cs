using System;
using System.Runtime.InteropServices;

namespace MiniMe.Core.Utilities
{
    public static class ConsoleUtility
    {
        private static Action _callbacks;

        static ConsoleUtility()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                SetConsoleCtrlHandler(WindowCtrlHandler, true);
            }

            AppDomain.CurrentDomain.ProcessExit += (s, e) => OnExit();
        }
        
        public static void HookExit(Action callback)
        {
            _callbacks += callback ?? throw new ArgumentNullException(nameof(callback));
        }

        private static void OnExit()
        {
            _callbacks?.Invoke();
            _callbacks = null;
        }

        private static bool WindowCtrlHandler(CtrlType signal)
        {
            OnExit();
            return true;
        }
        
        #region Windows
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);

        private delegate bool SetConsoleCtrlEventHandler(CtrlType signal);

        private enum CtrlType
        {
            CEvent = 0,
            BreakEvent = 1,
            CloseEvent = 2,
            LogoffEvent = 5,
            ShutdownEvent = 6
        }
        #endregion
    }
}
