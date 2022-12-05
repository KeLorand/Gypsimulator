using Godot;
using System;

public class Death : Node2D
{
    private Node2D ScriptNode;
    private GameHandler gameHandler;


    public override void _Ready()
    {
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
    }


    public void _on_Button2_pressed()
    {
        if (gameHandler.money >= 50000)
        {
            GD.Print("faszom");
        }
    }
}
