using Godot;
using System;

public class CarScript : Node2D
{

	public int movementSpeed;
	public Vector2 direction;

	public Sprite car;
	
 
	public override void _Ready()
	{
		movementSpeed = 500; 
		direction = new Vector2(0, 0);
		car = GetNode("KinematicBody2D/Sprite") as Sprite;
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
	   
		Position += direction.Normalized() * movementSpeed * deltaTime;

		
	}
}
