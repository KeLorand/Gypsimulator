using Godot;
using System;

public class Metal3 : Area2D
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
        gameHandler.points+= 10;
        QueueFree();
    }
}
