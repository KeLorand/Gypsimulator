using Godot;
using System;

public class CarScript : Node2D
{

	public Vector2 direction;
	public Sprite car;
	private Node2D ScriptNode;
    private GameHandler gameHandler;
	private bool isMoving = false;

	
 
	public override void _Ready()
	{
		direction = new Vector2(0, 0);
		car = GetNode("KinematicBody2D/Sprite") as Sprite;
		ScriptNode = GetNode("/root/Node2D") as Node2D;
        gameHandler = ScriptNode as GameHandler;
	}


	public override void _Process(float deltaTime)
	{


		direction.x = 0;
		direction.y = 0;
		if (Input.IsActionPressed("ui_left"))
		{
			direction.x -= 1;
			if (car.Scale.x > 0)
			{
				car.Scale = new Vector2(car.Scale.x * -1, car.Scale.y);
			}
		}
		if (Input.IsActionPressed("ui_right"))
		{
			direction.x += 1;
			if (car.Scale.x < 0)
			{
				car.Scale = new Vector2(car.Scale.x * -1, car.Scale.y);
			}
			
		}
		if (Input.IsActionPressed("ui_up"))
		{
			direction.y -= 1;
			
		}
		if (Input.IsActionPressed("ui_down"))
		{
			direction.y += 1;
		}

		if (Input.IsActionPressed("ui_down") || Input.IsActionPressed("ui_up") || Input.IsActionPressed("ui_right") || Input.IsActionPressed("ui_left"))
		{
			isMoving = true;
		}

		else
		{
			isMoving = false;
		}

		GD.Print(isMoving);

		if(isMoving == true)
		{
			gameHandler.FuelBar.Value = gameHandler.FuelBar.Value - 0.01f;
		}

		
		Position += direction.Normalized() * gameHandler.horsePower * 2 * deltaTime;
	
		
		

		
	}
}
