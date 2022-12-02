using Godot;
using System;

public class PoliceCar : Node2D
{
   
    private Node2D Car;
    private KinematicBody2D CarBody;

    private Vector2 target;

    private KinematicBody2D PoliceBody;

    public override void _Ready()
    {
        PoliceBody = GetNode("KinematicBody2D") as KinematicBody2D;
        Car = GetNode("/root/Node2D/Car") as Node2D; 
        CarBody = GetNode("/root/Node2D/Car/KinematicBody2D") as KinematicBody2D; 
    }


     public override void _Process(float delta)
    {   
      this.LookAt(CarBody.Position);
    }
}
