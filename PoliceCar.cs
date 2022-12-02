using Godot;
using System;

public class PoliceCar : Node2D
{

    private Vector2 direction;
    private Node2D Car;
    private Sprite CarBody;

    private KinematicBody2D PoliceBody;


    public override void _Ready()
    {
        direction = new Vector2(0, 0);
        PoliceBody = GetNode("KinematicBody2D") as KinematicBody2D;
        Car = GetNode("/root/Node2D/Car") as Node2D;
        CarBody = GetNode("/root/Node2D/Car/KinematicBody2D/Sprite") as Sprite;
    }


    public override void _Process(float delta)
    {
        this.LookAt(Car.Position + CarBody.Position);
        
    }
}
