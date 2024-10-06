using Godot;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

public partial class Master : Node3D
{
	[Export]
	Button refreshButton;

	[Export]
	OptionButton monthInput;
	[Export]
	TextEdit dayInput;
	[Export]
	TextEdit yearInput;

	[Export]
	OptionButton cropType;

	[Export]
	TextEdit longitude;
	[Export]
	TextEdit latitude;

	[Export]
	HttpRequest requester;
	[Export]
	string url;

	[Export]
	CropCreator cropCreator;

	[Export]
	public Slider slider;
	[Export]
	ProgressBar waterProgress;
	[Export]
	ProgressBar humidityProgress;
	[Export]
	ProgressBar temperatureProgress;
	[Export]
	ProgressBar growthProgress;
	[Export]
	ProgressBar growthRateProgress;
	[Export]
	Label currentMonthLabel;
	[Export]
	Label expectedGrowthCm;

	Returnable loadedData;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// dayInput.TextSet += validateDay;
		// yearInput.TextSet += validateYear;
		refreshButton.Pressed += RefreshButton_Pressed;
		requester.RequestCompleted += OnRequestCompleted;
		slider.DragEnded += changeSlider;
	}

	private void changeSlider(bool valueChanged)
	{
		if (valueChanged)
		{
			currentMonthLabel.Text = $"mes: {slider.Value}";

			waterProgress.Value = loadedData.Monthly[(int) slider.Value - 1].Waterfall;
			humidityProgress.Value = loadedData.Monthly[(int) slider.Value - 1].Humidity;
			temperatureProgress.Value = loadedData.Monthly[(int)slider.Value - 1].Waterfall;

			growthRateProgress.Value = loadedData.Monthly[(int)slider.Value -1].GrowthEffectiveness;
			growthProgress.Value = (slider.Value - 1.0) / (loadedData.Monthly.Count - 1.0) * 100.0;

			expectedGrowthCm.Text = $"Altura: {loadedData.Monthly[(int)slider.Value - 1].GrowthHeight}cm";
			cropCreator.updateCrops((int)growthProgress.Value);
		}
	}

	private void RefreshButton_Pressed()
	{
		MakePostRequest();
	}

	private void MakePostRequest()
	{

		// Data to send in the POST request (as JSON)
		var jsonData = new Godot.Collections.Dictionary
		{
			{ "startDate", DateTime.Now.ToString("") },
			{ "cropID", cropType.Selected },
			{ "latitud", 1.0000 },
			{ "longitude", 1.0000 },
		};
		string jsonString = Json.Stringify(jsonData);

		GD.Print(jsonString);

		// Create headers (if needed)
		var headers = new string[]
		{
			"Content-Type: application/json"
		};

		// Start the request
		var error = requester.Request(url, headers, HttpClient.Method.Post, jsonString);
		if (error != Error.Ok)
		{
			GD.Print("Error starting request: " + error);
		}
	}

	private void OnRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
	{
		GD.Print("Request completed with response code: " + responseCode);
		if (responseCode == 200) // Check for a successful response
		{
			string responseBody = System.Text.Encoding.UTF8.GetString(body);
			GD.Print("Response body: " + responseBody);
			Returnable returnable = JsonSerializer.Deserialize<Returnable>(responseBody);

			// GD.Print(returnable.Monthly[0].Humidity);
			cropCreator.x_offset = returnable.Crop.X;
			cropCreator.z_offset = returnable.Crop.Y;

			cropCreator.generateCrops();

			slider.MaxValue = returnable.Monthly.Count;

			waterProgress.MinValue = MyMath.lerp(returnable.Crop.MinWater, returnable.Crop.MaxWater, -0.25);
			waterProgress.MaxValue = MyMath.lerp(returnable.Crop.MinWater, returnable.Crop.MaxWater, 1.25);

			humidityProgress.MinValue = MyMath.lerp(returnable.Crop.MinHumidity, returnable.Crop.MaxHumidity, -0.25);
			humidityProgress.MaxValue = MyMath.lerp(returnable.Crop.MinHumidity, returnable.Crop.MaxHumidity, 1.25);

			temperatureProgress.MinValue = MyMath.lerp(returnable.Crop.MinTemp, returnable.Crop.MaxTemp, -0.25);
			temperatureProgress.MaxValue = MyMath.lerp(returnable.Crop.MinTemp, returnable.Crop.MaxTemp, 1.25);

			loadedData = returnable;

			slider.Editable = true;
			slider.Value = 1;

			changeSlider(true);
		}
		else
		{
			GD.Print("Error in request: " + responseCode);
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

public static class MyMath
{
	public static double lerp(double A, double B, double t)
	{
		return A + (B - A) * t;
	}
}

public class MonthData
{
	[JsonPropertyName("humidity")]
	public float Humidity { get; set; }

	[JsonPropertyName("waterfall")]
	public float Waterfall { get; set; }

	[JsonPropertyName("temperature")]
	public float Temperature { get; set; }

	[JsonPropertyName("growthPercentage")]
	public float GrowthPercentage { get; set; }

	[JsonPropertyName("growthEffectiveness")]
	public float GrowthEffectiveness { get; set; } = 100;

	[JsonPropertyName("growthHeight")]
	public float GrowthHeight { get; set; }
}

public class CropData
{
	[JsonPropertyName("x")]
	public float X { get; set; }

	[JsonPropertyName("y")]
	public float Y { get; set; }

	[JsonPropertyName("minHumidity")]
	public float MinHumidity { get; set; }

	[JsonPropertyName("maxHumidity")]
	public float MaxHumidity { get; set; }

	[JsonPropertyName("minTemp")]
	public float MinTemp { get; set; }

	[JsonPropertyName("maxTemp")]
	public float MaxTemp { get; set; }

	[JsonPropertyName("minWater")]
	public float MinWater { get; set; }

	[JsonPropertyName("maxWater")]
	public float MaxWater { get; set; }
}

public class Returnable
{
	[JsonPropertyName("monthly")]
	public List<MonthData> Monthly { get; set; }

	[JsonPropertyName("crop")]
	public CropData Crop { get; set; }
}

