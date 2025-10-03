using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ScrollDial;

internal static class GetCurrentApp
{
    [DllImport("user32.dll")]
    static extern int GetForegroundWindow();

    [DllImport("user32.dll")]
    static extern int GetWindowText(int hWnd, StringBuilder text, int count);

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    private static string lastTitle = "";
    private static int lastHandle;
    private static CurrentApp currentApp = new CurrentApp() { Name = "" };

    public static CurrentApp GetActiveWindow()
    {
        const int nChars = 256;
        StringBuilder sb = new StringBuilder(nChars);
        int handle = GetForegroundWindow();

        // Tonight's bonus question:
        // Why does GetWindowThreadProcessId return a UInt PID
        // When every other PID routine expects regular Ints?
        uint processId;
        GetWindowThreadProcessId(handle, out processId);

        if (processId != 0)
        {
            try
            {
                Process process = Process.GetProcessById((int)processId);
                Console.WriteLine($"Process Name: {process.ProcessName}");
                currentApp.Name = process.ProcessName;
                currentApp.ProcessID = (int)processId;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Process not found for the given ID.");
            }
        }
        else
        {
            Console.WriteLine("Could not retrieve process ID for the foreground window.");
        }
        return currentApp;
    }
}

public class CurrentApp
{
    public required string Name { get; set; }
    public int ProcessID { get; set; }
}
