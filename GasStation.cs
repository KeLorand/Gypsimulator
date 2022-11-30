using Godot;
using System;

public class GasStation : Node2D
{

    private Node2D ScriptNode;
    private GameHandler gameHandler;


    public override void _Ready()
    {
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
    }


    public override void _Process(float delta)
    {
         GD.Print((100 - gameHandler.FuelBar.Value) * 300);
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {

       

        if (gameHandler.money > (100 - gameHandler.FuelBar.Value) * 300)
        {
            gameHandler.money = gameHandler.money - (100 - gameHandler.FuelBar.Value) * 300;
            gameHandler.FuelBar.Value = 100;
        }

    }
  
}
