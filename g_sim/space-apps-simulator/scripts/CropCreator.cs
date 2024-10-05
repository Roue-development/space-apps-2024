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

	private List<Crop> crops;
	// public float 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();


	}

	public void generateCrops()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
