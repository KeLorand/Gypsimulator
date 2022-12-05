using Godot;
using System;

public class Gypsy : Node2D
{

    private Node2D ScriptNode;
    private GameHandler gameHandler;
    private float gypsyFTimer;
    private float gypsyFWait = 4f;
    private float screenTimer;
    private float screenWait = 12f;

    private Sprite GypsySprite;
    private bool rotated = false;
    private Sprite StealSprite;
    private Label StealText;
    private PhysicsBody2D PlayerBody;

    public override void _Ready()
    {
        GypsySprite = GetNode("Area2D/Sprite") as Sprite;
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
        StealSprite = GetNode("/root/Node2D/Car/StealScreen") as Sprite;
        PlayerBody = GetNode("/root/Node2D/Car/KinematicBody2D") as PhysicsBody2D;
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        if (body == PlayerBody)
        {
            gameHandler.points = 0;
            StealSprite.Visible = true;
            GD.Print("A cigány ellopta az összes vasad!");
        }

    }

    public override void _Process(float delta)
    {
        gypsyFTimer += delta;

        if (StealSprite.Visible == true)
        {
            screenTimer += delta;
            if (screenTimer >= screenWait)
            {
                StealSprite.Visible = false;
                screenTimer = 0;
            }
        }

        if (gypsyFTimer > 0 && gypsyFTimer < 2)
        {
            GypsySprite.RotationDegrees = 180;
            this.Translate(new Vector2(0, 1));
        }

        if (gypsyFTimer > 2 && gypsyFTimer < gypsyFWait)
        {
            GypsySprite.RotationDegrees = 0;
            this.Translate(new Vector2(0, -1));
        }

        if (gypsyFTimer >= gypsyFWait)
        {
            gypsyFTimer = 0;
        }
    }
}
