using Godot;
using System;

public class Helicopter : Node2D
{

    private Node2D ScriptNode;
    private GameHandler gameHandler;
    private Random rng = new Random();
    private PhysicsBody2D PlayerBody;
    private Sprite rotor;
    private Sprite PoliceScreen;
    private float screenTimer;
    private float screenWait = 12f;


    public override void _Ready()
    {
        PlayerBody = GetNode("/root/Node2D/Car/KinematicBody2D") as PhysicsBody2D;
        PoliceScreen = GetNode("/root/Node2D/Car/PoliceScreen") as Sprite;
        rotor = GetNode("Area2D/Rotor") as Sprite;
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
    }

    public override void _Process(float delta)
    {
        this.Translate(new Vector2(-7, 0));
        if (this.Position.x <= -1349)
        {
            this.Position = new Vector2(2957, rng.Next(-1021, 1357));
        }
        rotor.RotationDegrees += 20;
        if (rotor.RotationDegrees >= 360)
        {
            rotor.RotationDegrees = 0;
        }
        if (PoliceScreen.Visible == true)
        {
            screenTimer += delta;
            if (screenTimer >= screenWait)
            {
                PoliceScreen.Visible = false;
                screenTimer = 0;
            }
        }
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        if (body == PlayerBody)
        {
            gameHandler.FuelBar.Value -= 50;
            PoliceScreen.Visible = true;
        }
    }
}
