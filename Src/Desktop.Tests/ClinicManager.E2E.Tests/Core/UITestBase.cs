using FlaUI.Core;
using FlaUI.Core.Capturing;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.WindowsAPI;
using FlaUI.TestUtilities;
using NUnit.Framework;
using OperatingSystem = FlaUI.Core.Tools.OperatingSystem;

namespace ClinicManager.E2E.Tests.Core;

public abstract class UITestBase : FlaUITestBase2
{
    static string ApplicationPath = string.Format("..\\..\\ClinicManager.Win\\debug\\ClinicMgr.exe",Environment.CurrentDirectory);
    static UITestBase()
    {
        NativeMethods.SetProcessDPIAware();
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

        Mouse.MovePixelsPerMillisecond = 2;
        Retry.DefaultTimeout = TimeSpan.FromSeconds(5);
        Retry.DefaultInterval = TimeSpan.FromMilliseconds(250);
    }

    protected override AutomationBase GetAutomation()
        {
            return new UIA3Automation();
        }
        
    protected override Application StartApplication()
        {
            return FlaUI.Core.Application.Launch(ApplicationPath);
        }
        
    
    
    private static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetProcessDPIAware();
    }
}
