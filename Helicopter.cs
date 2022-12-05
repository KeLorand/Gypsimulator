using Godot;
using System;

public class Helicopter : Node2D
{

    private Random rng = new Random();
    private PhysicsBody2D PlayerBody;

    public override void _Ready()
    {
         PlayerBody = GetNode("/root/Node2D/Car/KinematicBody2D") as PhysicsBody2D;
    }

    public override void _Process(float delta)
    {
        if (this.Position.x <= -1349)
        {
            this.Position = new Vector2(2957, rng.Next(1021, 1357));
        }
        this.Translate(new Vector2(-8, 0));
    }
}
