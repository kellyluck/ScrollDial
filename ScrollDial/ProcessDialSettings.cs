namespace ScrollDial;

internal class ProcessDialSettings
{
    public required string ProcessName { get; set; } = "";
    public KeyEventArgs? CW_NoButton { get; set; }
    public KeyEventArgs? CW_Button { get; set; }
    public KeyEventArgs? CCW_NoButton { get; set; }
    public KeyEventArgs? CCW_Button { get; set; }
}

