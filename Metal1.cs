using Godot;
using System;

public class Metal1 : Area2D
{



    private Node2D MainNode;
    private GameHandlerScript gameHandler;


    public override void _Ready()
    {
        MainNode = GetNode("GameHandler") as Node2D;
        gameHandler = MainNode as GameHandlerScript;
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        
        QueueFree();
    }
}
