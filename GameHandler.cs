using Godot;
using System;

public class GameHandler : Node2D
{

	private Label metalLabel;
	private Label moneyLabel;
	[Export] PackedScene Metal1;
	[Export] PackedScene Metal2;
	[Export] PackedScene Metal3;
	private Random rng = new Random();
	private float metal1timerTime;
	private float metal1timerWaitTime = 5f;
	private float metal2timerTime;
	private float metal2timerWaitTime = 10f;
	private float metal3timerTime;
	private float metal3timerWaitTime = 30f;
	public int points = 0;
	public double money = 0;
	public int horsePower = 180;
	public bool canMove = true;
	public ProgressBar FuelBar;
	private Node2D DeathScreen;
	
	public override void _Ready()
	{
		metalLabel = GetNode("Car/MetalLabel") as Label;
		moneyLabel = GetNode("Car/MoneyLabel") as Label;
		FuelBar = GetNode("Car/Fuel/ProgressBar") as ProgressBar;
		DeathScreen = GetNode("Car/DeathScreen") as Node2D;
	}

	
	public override void _Process(float delta)
	{
		
		FormatPoints();
		MetalSpawner(delta);
		NoFuel();

		moneyLabel.Text = money.ToString();


	}

	void SpawnMetal1()
	{
		Node2D metal1 = (Node2D)Metal1.Instance();
		metal1.Position = new Vector2(rng.Next(-1095, 2806), rng.Next(-1387, 0));
		this.AddChild(metal1);
	}

	void SpawnMetal2()
	{
		Node2D metal2 = (Node2D)Metal2.Instance();
		metal2.Position = new Vector2(rng.Next(-1095, 2806), rng.Next(-1387, 0));
		this.AddChild(metal2);
	}

	void SpawnMetal3()
	{
		Node2D metal3 = (Node2D)Metal3.Instance();
		metal3.Position = new Vector2(rng.Next(-1095, 2806), rng.Next(-1387, 0));
		this.AddChild(metal3);
	}

	void FormatPoints()
	{
		if (points == 0)
		{
			metalLabel.Text = ($"Fém értéke: 0 Forint");
		}

		if (points == 1)
		{
			metalLabel.Text = ($"Fém értéke: Ezer Forint");
		}

		if (points > 1)
		{
			metalLabel.Text = ($"Fém értéke: {points} Ezer Forint");
		}
	}

	void MetalSpawner(float delta)
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

	void NoFuel()
	{
		if (FuelBar.Value == 0)
		{
			canMove = false;
			DeathScreen.Visible = true;
		}
	}
}
