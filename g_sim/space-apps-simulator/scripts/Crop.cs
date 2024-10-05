using Godot;
using System;

public partial class Crop : MeshInstance3D
{
	int state = 0;
	Mesh[] meshList;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void initialize(Mesh[] meshes, int state = 0)
	{
		meshList = meshes;
		this.Mesh = meshList[state];
		this.state = state;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
