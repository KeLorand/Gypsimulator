using Godot;
using System;

public class PoliceCar : Node2D
{

    private Vector2 direction;
    private Node2D Car;
    private Sprite CarBody;

    private KinematicBody2D PoliceBody;
    private Sprite PoliceCarBody;

    private float _t = 0.0f;


    public override void _Ready()
    {
        direction = new Vector2(0, 0);
        PoliceBody = GetNode("KinematicBody2D") as KinematicBody2D;
        Car = GetNode("/root/Node2D/Car") as Node2D;
        CarBody = GetNode("/root/Node2D/Car/KinematicBody2D/Sprite") as Sprite;
        PoliceCarBody = GetNode("KinematicBody2D/Sprite") as Sprite;
    }


    public override void _PhysicsProcess(float delta)
    {
        _t += delta * 10f;

        Position2D a = GetNode<Position2D>("KinematicBody2D/A");
        Position2D b = Car.GetNode<Position2D>("KinematicBody2D/Sprite/B");
        PoliceCarBody.Position = a.Position.LinearInterpolate(b.Position, _t);
    }
}
