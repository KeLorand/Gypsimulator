using Godot;
using System;

public class Mobile : Node2D
{

    private DateTime curTime = DateTime.Now;

    private Sprite MobileUI;
    private Button MobileOpen;
    private Button MobileClose;
    private Label SysTimeLabel;
    private Sprite TuningMenu;
    private int hour;
    private int minute;
    


    public override void _Ready()
    {
        MobileUI = GetNode("MobileBG") as Sprite;
        MobileOpen = GetNode("MobileOpen") as Button;
        MobileClose = GetNode("MobileClose") as Button;
        SysTimeLabel = GetNode("MobileBG/MobileUI/SysTime") as Label;
        TuningMenu = GetNode("MobileBG/MobileUI/Sprite") as Sprite;
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
    }

    public void _on_TuningClose_pressed()
    {
        TuningMenu.Visible = false;
    }

    public void _on_TuningOpen_pressed()
    {
        TuningMenu.Visible = true;
    }

}
