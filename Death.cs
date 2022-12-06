using Godot;
using System;

public class Death : Node2D
{
    private Node2D ScriptNode;
    private Node2D CarNode;
    private GameHandler gameHandler;


    public override void _Ready()
    {
        ScriptNode = GetNode("/root/Node2D") as Node2D;
        CarNode = GetNode("/root/Node2D/Car") as Node2D;
        gameHandler = ScriptNode as GameHandler;
    }

    public override void _Process(float delta)
    {
        this.Position = new Vector2(CarNode.Position.x - 180, CarNode.Position.y + 90);
    }

    public void _on_Button_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Menu.tscn");
    }

    public void _on_Button2_pressed()
    {
        if (gameHandler.money >= 50000)
        {
            gameHandler.FuelBar.Value += 50;
            gameHandler.money -= 50000;
        }
    }
}
