using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeSnippetTool.Hotkeys
{
    /// <summary>
    /// Adding/removing hotkeys
    /// </summary>
    public static class HotkeyFirst
    {
        //Windows callback
        //Windows callback for key strokes to register
        private delegate IntPtr LowLevelKeyBoardProc(int nCode, IntPtr wParam, IntPtr lParam);

        //Specifies a static callback method
        private static LowLevelKeyBoardProc LowLevelProc = HookCallBack;

        //Contains all application hotkeys
        private static List<HotkeyListener> Hotkeys { get; set; }

        //Call helpers
        //Proc ID for windows to determine strokes
        //Type of hook for low level strokes
        private const int WH_KEYBOARD_LL = 13;

        //Store HookID
        private static IntPtr HookID = IntPtr.Zero;

        //CHeck if hook is setup or not
        public static bool isHookSetup { get; set; }

        static HotkeyFirst()
        {
            Hotkeys = new List<HotkeyListener>();
        }

        public static void SetupSystemHook()
        {
            if (!isHookSetup)
            {
                HookID = SetHook(LowLevelProc);
                isHookSetup = true;
            }
        }

        public static void ShutdownSystemHook()
        {
            if (isHookSetup)
            {
                UnhookWindowsHookEx(HookID);
                isHookSetup = false;
            }
        }

        public static void AddHotkey(HotkeyListener hotkey)
        {
            Hotkeys.Add(hotkey);
        }

        public static void RemoveHotkey(HotkeyListener hotkey)
        {
            Hotkeys.Remove(hotkey);
        }

        //Setup hook with specified callback(proc)
        private static IntPtr SetHook(LowLevelKeyBoardProc proc)
        {
            using (Process currentProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule currentModule = currentProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(currentModule.ModuleName), 0);
                }
            }
        }

        private static IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //Scans for hotkeys

            //Check nCode if sent key is down or not
            if (nCode >= 0)
            {
                foreach (HotkeyListener hotkey in Hotkeys)
                {

                    if (Keyboard.Modifiers == hotkey.Modifier && Keyboard.IsKeyDown(hotkey.Key))
                    {
                        if (hotkey.CanExecute)
                        {
                            hotkey.Callback?.Invoke();
                        }
                    }
                }
            }

            return CallNextHookEx(HookID, nCode, wParam, lParam);
        }

        //DLL imported methods for hooks
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyBoardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        //Method for getting module handle
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
