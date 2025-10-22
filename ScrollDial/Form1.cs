using Newtonsoft.Json;
using System.Diagnostics;
using System.IO.Ports;
using System.Text.Json;
using System.Timers;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Timer = System.Timers.Timer;

namespace ScrollDial;

public partial class Form1 : Form
{
    List<ProcessDialSettings> dialSettings = new List<ProcessDialSettings>();
    ProcessDialSettings currentSetting;
    string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keysettings.json");
    SerialPort serialPort = new SerialPort();

    public Form1()
    {
        InitializeComponent();
        Startup();
    }

    public void Startup()
    {
        InitSerialPort();

        Timer timer = new Timer(1000);
        timer.Elapsed += CheckCurrentApp;
        timer.AutoReset = true;
        timer.Enabled = true;

        LoadSettings();
        LoadProcessList();
    }

    private void InitSerialPort()
    {
        serialPort.BaudRate = 9600;
        serialPort.PortName = "COM4";
        serialPort.Open();
        serialPort.DataReceived += SerialPort_DataReceived;
    }

    private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string dialInput = serialPort.ReadLine();
        CurrentApp currentApp = GetCurrentApp.GetActiveWindow();

        var currentSettings = dialSettings.FirstOrDefault(d => d.ProcessName == currentApp.Name);
        if (currentSettings != null)
        {
            KeyEventArgs keystroke = null;
            switch (dialInput)
            {
                case "CW|Y":
                    if (currentSettings.CW_Button != null) keystroke = currentSettings.CW_Button;
                    break;
                case "CCW|Y":
                    if (currentSettings.CCW_Button != null) keystroke = currentSettings.CCW_Button;
                    break;
                case "CW|N":
                    if (currentSettings.CW_NoButton != null) keystroke = currentSettings.CW_NoButton;
                    break;
                case "CCW|N":
                    if (currentSettings.CCW_NoButton != null) keystroke = currentSettings.CCW_NoButton;
                    break;
                default:
                    break;
            }
            if (keystroke != null)
            {
                SendToProcess(currentApp.ProcessID, keystroke);
            }
        }
    }

    public void LoadProcessList()
    {
        lstProcesses.Items.Clear();
        var allProcesses = Process.GetProcesses()
            .Where(p => p.MainWindowHandle != 0)
            .GroupBy(p => p.ProcessName)
            .Select(p => p.First())
            .OrderBy(p => p.ProcessName)
            .ToList();
        foreach (var process in allProcesses)
        {
            lstProcesses.Items.Add(process.ProcessName);
        }
    }

    public void CheckCurrentApp(object? src, ElapsedEventArgs e)
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

        // quick dumb proof of concept: if current foreground app is notepad, type in the time.
        //if (currentApp.Name.ToLower() == "notepad")
        //{
        //    SendToNotepad(currentApp.ProcessID, DateTime.Now.ToShortTimeString() + "\n");
        //}
    }

    public void SendToProcess(int processID, KeyEventArgs keystroke)
    {
        Process p = Process.GetProcessById(processID);
        if (p != null)
        {
            IntPtr h = p.MainWindowHandle;
            //SendKeys.Send(note);
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadProcessList();
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void lstProcesses_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblProcessName.Text = lstProcesses.Text.ToString();

        currentSetting = dialSettings.FirstOrDefault(s => s.ProcessName == lblProcessName.Text);
        if (currentSetting == null)
        {
            currentSetting = new ProcessDialSettings() { ProcessName = lblProcessName.Text };
        }
        else
        {
            txtCWnoB.Text = currentSetting.CW_NoButton?.KeyCode.ToString();
            txtCWB.Text = currentSetting.CW_Button?.KeyCode.ToString();
            txtCCWNoB.Text = currentSetting.CCW_NoButton?.KeyCode.ToString();
            txtCCWB.Text = currentSetting.CCW_Button?.KeyCode.ToString();
        }

        grpAssignments.Enabled = true;
    }

    private void TxtCWnoB_KeyUp(object sender, KeyEventArgs e)
    {
        //Debug.WriteLine($"{e.KeyData}, {e.KeyValue}, {e.KeyCode}");
        currentSetting.CW_NoButton = e;
        txtCWnoB.Text = e.KeyCode.ToString();
        btnSave.Enabled = true;
    }

    private void TxtCCWB_KeyUp(object sender, KeyEventArgs e)
    {
        currentSetting.CCW_Button = e;
        txtCCWB.Text = e.KeyCode.ToString();
        btnSave.Enabled = true;
    }

    private void TxtCCWNoB_KeyUp(object sender, KeyEventArgs e)
    {
        currentSetting.CCW_NoButton = e;
        txtCCWNoB.Text = e.KeyCode.ToString();
        btnSave.Enabled = true;
    }

    private void TxtCWB_KeyUp(object sender, KeyEventArgs e)
    {
        currentSetting.CW_Button = e;
        txtCWB.Text = e.KeyCode.ToString();
        btnSave.Enabled = true;
    }


    private void btnSave_Click(object sender, EventArgs e)
    {
        if (lstProcesses.SelectedIndex == -1)
        {
            return;
        }
        SaveSettings();
    }

    private void LoadSettings()
    {
        if (!File.Exists(settingsFile))
        {
            return;
        }

        string json = File.ReadAllText(settingsFile);
        dialSettings = JsonConvert.DeserializeObject<List<ProcessDialSettings>>(json);
    }

    private void SaveSettings()
    {
        var existingSetting = dialSettings.FirstOrDefault(s => s.ProcessName == lblProcessName.Text);
        if (existingSetting != null)
        {
            dialSettings.Remove(existingSetting);
        }

        dialSettings.Add(currentSetting);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(dialSettings, options);
        File.WriteAllTextAsync(settingsFile, json);

        btnSave.Enabled = false;
    }


}
