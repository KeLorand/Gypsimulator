using Godot;
using System;

public class Meh : Node2D
{
    private Node2D ScriptNode;
    

    private GameHandler gameHandler;
    public override void _Ready()
    {
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        gameHandler.money += gameHandler.points * 1000;
        gameHandler.points = 0;
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
