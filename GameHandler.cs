using Godot;
using System;

public class GameHandler : Node2D
{


    [Export] PackedScene Metal1;
    [Export] PackedScene Metal2;
    [Export] PackedScene Metal3;

    private Random rng = new Random();

    private float metal1timerTime;
    private float metal1timerWaitTime = 5f;

    private float metal2timerTime;
    private float metal2timerWaitTime = 10f;

    private float metal3timerTime;
    private float metal3timerWaitTime = 20f;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

        metal1timerTime += delta;
        metal2timerTime += delta;
        metal3timerTime += delta;

        if (metal1timerTime >= metal1timerWaitTime)
        {
            SpawnMetal1();
            metal1timerTime = 0f;
        }

        if (metal2timerTime >= metal2timerWaitTime)
        {
            SpawnMetal2();
            metal2timerTime = 0f;
        }

        if (metal3timerTime >= metal3timerWaitTime)
        {
            SpawnMetal3();
            metal3timerTime = 0f;
        }


    }

    void SpawnMetal1()
    {
        Node2D metal1 = (Node2D)Metal1.Instance();
        metal1.Position = new Vector2(rng.Next(0, 1280), rng.Next(0, 1280));
        this.AddChild(metal1);
    }

    void SpawnMetal2()
    {
        Node2D metal2 = (Node2D)Metal2.Instance();
        metal2.Position = new Vector2(rng.Next(0, 1280), rng.Next(0, 1280));
        this.AddChild(metal2);
    }

    void SpawnMetal3()
    {
        Node2D metal3 = (Node2D)Metal3.Instance();
        metal3.Position = new Vector2(rng.Next(0, 1280), rng.Next(0, 1280));
        this.AddChild(metal3);
    }
}
