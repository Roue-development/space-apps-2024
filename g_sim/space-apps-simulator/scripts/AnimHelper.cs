using Godot;
using System;

public partial class AnimHelper : AnimationPlayer
{
	[Export]
	public Button view1;
	[Export]
	public Button view2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Play("cam anim");

		view1.Pressed += () => PlayOther("cam anim");
		view2.Pressed += () => PlayOther("cam idle");

	}

	public void PlayOther(string name)
	{
		Play(name);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
