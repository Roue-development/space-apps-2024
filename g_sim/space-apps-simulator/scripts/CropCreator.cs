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
	public Mesh[] cropMaturity_corn = new Mesh[] { };
	[Export]
	public Mesh[] cropMaturity_beans = new Mesh[] { };
	[Export]
	public Mesh[] cropMaturity_sorgo = new Mesh[] { };

	[Export]
	public Slider slider;
	[Export]
	public OptionButton selectedType;

	private List<Crop> created_crops;
	// public float 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		created_crops = new();

		generateCrops();

		slider.DragEnded += changeSlider;
		selectedType.ItemSelected += changeSelectedCrop;
	}

    private void changeSelectedCrop(long index)
    {
        generateCrops();
    }

    private void changeSlider(bool valueChanged)
	{
		if (valueChanged)
		{
			changeSlider((int)slider.Value);
		}
	}



	private Mesh[] getSelected()
	{
		var type = selectedType.Selected;

		switch (type)
		{
			case 0:
				return cropMaturity_corn;
			case 1:
				return cropMaturity_beans;
			case 2:
				return cropMaturity_sorgo;
			default:
				return cropMaturity_corn;
		}
	}

	public void generateCrops(int maturity = 0)
	{
		foreach (var crop in created_crops)
		{
			crop.QueueFree();
		}
		created_crops = new();

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

				src.initialize(getSelected(), maturity);

				src.Position = new Vector3(x_pos, (float)(y_startPos + (randomizer.NextDouble() - 0.5) * 0.1), z_pos);
				src.RotateY((float)(randomizer.NextDouble() * 2.0 * Math.PI));

				AddChild(src);
				created_crops.Add(src);
			}
		}
	}

	public void changeSlider(int pos)
	{
		updateCrops(pos);
	}

	public void updateCrops(int maturity = 0)
	{
		int selectedmaturity;


		if (maturity < 20)
			selectedmaturity = 0;
		else if (maturity < 40)
			selectedmaturity = 1;
		else if (maturity < 60)
			selectedmaturity = 2;
		else if (maturity < 80)
			selectedmaturity = 3;
		else
			selectedmaturity = 4;

		foreach (var crop in created_crops)
		{
			crop.state = selectedmaturity;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
