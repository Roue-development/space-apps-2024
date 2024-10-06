using Godot;
using System;
using System.Collections.Generic;

public partial class CropCreator : Node3D
{
	[Export]
	public float y_startPos;
	[Export]
	public float x_offset;
	[Export]
	public float z_offset;

	[Export]
	public Mesh[] cropMaturity = new Mesh[] { };

	private List<Crop> created_crops;
	// public float 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		created_crops = new();

		generateCrops();
	}

	public void generateCrops(int maturity = 0)
	{
		int x_amount = (int)(50 / x_offset);
		int z_amount = (int)(50 / z_offset);

		var randomizer = new Random();

		for (int x = 0; x < x_amount; x++)
		{
			var x_pos = x * x_offset;
			for (int z = 0; z < z_amount; z++)
			{
				var z_pos = z * z_offset;

				var src = new Crop();

				src.initialize(cropMaturity, maturity);

				src.Position = new Vector3(x_pos, (float)(y_startPos + randomizer.NextDouble() -0.5), z_pos);
				src.RotateY((float)(randomizer.NextDouble() * 2.0 * Math.PI));

				AddChild(src);
				created_crops.Add(src);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
