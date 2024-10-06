import schema

import fastapi

app = fastapi.FastAPI()


@app.post("/")
def getData(data: schema.AskFordata) -> schema.Returnable:
    match data.cropID:
        case 0:
            # elote
            return schema.Returnable(
                monthly=[
                    schema.MonthData(
                        humidity=30,
                        waterfall=492,
                        temperature=30,
                        growthPercentage=10,
                        growthEffectiveness=90,
                        growthHeight=50,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=238,
                        temperature=31,
                        growthPercentage=20,
                        growthEffectiveness=80,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=29,
                        waterfall=272,
                        temperature=32,
                        growthPercentage=30,
                        growthEffectiveness=70,
                        growthHeight=150,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=333,
                        temperature=30,
                        growthPercentage=30,
                        growthEffectiveness=80,
                        growthHeight=200,
                    ),
                    schema.MonthData(
                        humidity=29,
                        waterfall=358,
                        temperature=28,
                        growthPercentage=30,
                        growthEffectiveness=80,
                        growthHeight=250,
                    ),
                ],
                crop=schema.CropData(
                    x=0.5,
                    y=0.8,
                    minHumidity=28,
                    maxHumidity=32,
                    minTemp=25,
                    maxTemp=38,
                    minWater=500,
                    maxWater=800,
                )
            )
        case 1:
            # frijol
            return schema.Returnable(
                monthly=[
                    schema.MonthData(
                        humidity=30,
                        waterfall=492,
                        temperature=30,
                        growthPercentage=10,
                        growthEffectiveness=70,
                        growthHeight=11,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=238,
                        temperature=28,
                        growthPercentage=20,
                        growthEffectiveness=90,
                        growthHeight=22,
                    ),
                    schema.MonthData(
                        humidity=29,
                        waterfall=272,
                        temperature=27,
                        growthPercentage=30,
                        growthEffectiveness=100,
                        growthHeight=33,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=333,
                        temperature=28,
                        growthPercentage=30,
                        growthEffectiveness=100,
                        growthHeight=45,
                    ),
                ],
                crop=schema.CropData(
                    x=0.1,
                    y=0.8,
                    minHumidity=60,
                    maxHumidity=70,
                    minTemp=10,
                    maxTemp=27,
                    minWater=300,
                    maxWater=500,
                )
            )
        case 2:
            # sorbo
            return schema.Returnable(
                monthly=[
                    schema.MonthData(
                        humidity=30,
                        waterfall=492,
                        temperature=30,
                        growthPercentage=10,
                        growthEffectiveness=90,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=238,
                        temperature=29,
                        growthPercentage=20,
                        growthEffectiveness=80,
                        growthHeight=200,
                    ),
                    schema.MonthData(
                        humidity=29,
                        waterfall=272,
                        temperature=28,
                        growthPercentage=30,
                        growthEffectiveness=70,
                        growthHeight=300,
                    ),
                ],
                crop=schema.CropData(
                    x=0.15,
                    y=0.7,
                    minHumidity=18,
                    maxHumidity=20,
                    minTemp=20,
                    maxTemp=30,
                    minWater=400,
                    maxWater=650,
                )
            )
