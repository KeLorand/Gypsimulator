using Godot;
using System;

public class GameHandlerScript : Node2D
{
    public int Points = 0;
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GD.Print(Points);
    }
}
