using Godot;
using System;

public class Metal2 : Area2D
{
    public override void _Ready()
    {
        
    }


    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        QueueFree();
    }
}
