using ClinicManager.E2E.Tests.Core;
using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.TestUtilities;
using FlaUI.UIA3;
using FlaUI.Core.AutomationElements;

namespace ClinicManager.E2E.Tests;

  [TestFixture]
  public class AccountTest : UITestBase
  {
    [Test]
    [KeepVideo]
    public void TransferFunds()
    {
      // 1. Get the window by filtering the app's top-level windows
var window = Retry.WhileNull(() => 
    Application.GetAllTopLevelWindows(Automation)
       .FirstOrDefault(x => x.AutomationId == "ShellWindow"), 
    TimeSpan.FromSeconds(10)
).Result;

// 2. Wait until it is visible (not off-screen)
if (window != null)
{
    Retry.WhileTrue(() => window.IsOffscreen, TimeSpan.FromSeconds(10));
}
    }
  }

