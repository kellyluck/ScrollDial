using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ScrollDial;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Startup();
    }

    public void Startup()
    {
        Timer timer = new Timer(1000);
        timer.Elapsed += CheckCurrentApp;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    public void CheckCurrentApp(object _, ElapsedEventArgs __)
    {
        CurrentApp currentApp = GetCurrentApp.GetActiveWindow();
        if (lblCurrentApp.InvokeRequired)
        {
            lblCurrentApp.Invoke((MethodInvoker)delegate
            {
                lblCurrentApp.Text = currentApp.Name;
            });
        }
        else
        {
            lblCurrentApp.Text = currentApp.Name;
        }

        if (currentApp.Name.ToLower() == "notepad")
        {
            SendToNotepad(currentApp.ProcessID, DateTime.Now.ToShortTimeString() + "\n");

        }
    }

    public void SendToNotepad(int processID, string note)
    {
        Process p = Process.GetProcessById(processID);
        if (p != null)
        {
            IntPtr h = p.MainWindowHandle;
            SendKeys.SendWait(note);
        }
    }
    
}
