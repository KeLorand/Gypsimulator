using Godot;
using System;

public class Gypsy : Node2D
{

    private Node2D ScriptNode;
    private GameHandler gameHandler;
    private float gypsyFTimer;
    private float gypsyFWait = 4f;
    private Sprite GypsySprite;
    private bool rotated = false;

    public override void _Ready()
    {
        GypsySprite = GetNode("Area2D/Sprite") as Sprite;
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        gameHandler.points = 0;
        GD.Print("A cigány ellopta az összes vasad!");
    }

    public override void _Process(float delta)
    {
        gypsyFTimer += delta;


        if (gypsyFTimer > 0 && gypsyFTimer < 2)
        {
            GypsySprite.RotationDegrees =  180;
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
