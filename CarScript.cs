using Godot;
using System;

public class CarScript : Node2D
{

	public Vector2 direction;
	public Sprite car;
	private CollisionShape2D carCollider;
	private Node2D ScriptNode;
    private GameHandler gameHandler;
	private bool isMoving = false;

	
 
	public override void _Ready()
	{
		direction = new Vector2(0, 0);
		car = GetNode("KinematicBody2D/Sprite") as Sprite;
		ScriptNode = GetNode("/root/Node2D") as Node2D;
		carCollider = GetNode("KinematicBody2D/CarCollider") as CollisionShape2D;
        gameHandler = ScriptNode as GameHandler;
	}


	public override void _Process(float deltaTime)
	{


		direction.x = 0;
		direction.y = 0;
		if (Input.IsActionPressed("ui_left"))
		{
			direction.x -= 1;
			car.RotationDegrees = -90;
			carCollider.RotationDegrees = -90;
		}
		if (Input.IsActionPressed("ui_right"))
		{
			direction.x += 1;
			car.RotationDegrees = 90;
			carCollider.RotationDegrees = 90;	
		}
		if (Input.IsActionPressed("ui_up"))
		{
			direction.y -= 1;
			car.RotationDegrees = 0;
			carCollider.RotationDegrees = 0;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			direction.y += 1;
			car.RotationDegrees = 180;
			carCollider.RotationDegrees = 180;
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
			gameHandler.FuelBar.Value = gameHandler.FuelBar.Value - 0.025f;
		}

		if (gameHandler.canMove == true)
		{
			Position += direction.Normalized() * gameHandler.horsePower * 2 * deltaTime;
		}
		
	
		
		

		
	}
}
