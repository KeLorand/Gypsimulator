using Godot;
using System;

public class Metal1 : Area2D
{


    private Node2D ScriptNode;
    

    private GameHandler gameHandler;
    private PhysicsBody2D PlayerBody;




    public override void _Ready()
    {

        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
        PlayerBody = GetNode("/root/Node2D/Car/KinematicBody2D") as PhysicsBody2D;
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        if (body == PlayerBody)
        {
            gameHandler.points++;
            QueueFree();
        }
       
    }
}
