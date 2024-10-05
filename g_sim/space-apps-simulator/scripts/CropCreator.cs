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

		generateCrops();
	}

	public void generateCrops(int maturity = 0)
	{
		int x_amount = 50;
		int z_amount = 50;


		for (int x = 0; x < x_amount; x++)
		{
			var x_pos = x * x_offset;
			for (int z = 0; z < z_amount; z++)
			{
				var z_pos = z * z_offset;

				var obj = new MeshInstance3D();
				var src = new Crop();

				obj.Mesh = cropMaturity[maturity];
				obj.SetScript(src);

				src.

				AddChild(obj);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
