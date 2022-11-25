using Godot;
using System;

public class Mobile : Node2D
{

    private Sprite MobileUI;
    private Button MobileOpen;
    private Button MobileClose;

    public override void _Ready()
    {
        MobileUI = GetNode("MobileUI") as Sprite;
        MobileOpen = GetNode("MobileOpen") as Button;
        MobileClose = GetNode("MobileClose") as Button;
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

    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
