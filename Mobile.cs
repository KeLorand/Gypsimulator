using Godot;
using System;

public class Mobile : Node2D
{

    private DateTime curTime = DateTime.Now;

    private Sprite MobileUI;
    private Button MobileOpen;
    private Button MobileClose;
    private Label SysTimeLabel;
    private int hour;
    private int minute;
    


    public override void _Ready()
    {
        MobileUI = GetNode("MobileBG") as Sprite;
        MobileOpen = GetNode("MobileOpen") as Button;
        MobileClose = GetNode("MobileClose") as Button;
        SysTimeLabel = GetNode("MobileBG/MobileUI/SysTime") as Label;
    }

    public void _on_Button_pressed()
    {
        MobileUI.Visible = true;
        MobileClose.Visible = true;
        MobileOpen.Visible = false;
    }

    public void _on_MobileClose_pressed()
    {
        MobileUI.Visible = false;
        MobileClose.Visible = false;
        MobileOpen.Visible = true;
    }

    public override void _Process(float deltaTime)
    {
        curTime = DateTime.Now;
        hour = curTime.Hour;
        minute = curTime.Minute;
        SysTimeLabel.Text = $"{hour}:{minute}";
        GD.Print($"{hour}:{minute}");
    }

}
