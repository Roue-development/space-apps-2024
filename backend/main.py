from . import schema

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
                        humidity=10,
                        waterfall=10,
                        temperature=10,
                        growthPercentage=10,
                        growthEffectiveness=20,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=20,
                        waterfall=20,
                        temperature=20,
                        growthPercentage=20,
                        growthEffectiveness=20,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=30,
                        temperature=30,
                        growthPercentage=30,
                        growthEffectiveness=30,
                        growthHeight=100,
                    ),
                ],
                crop=schema.CropData(
                    x=0.5,
                    y=0.5,
                    minHumidity=50,
                    maxHumidity=60,
                    minTemp=15,
                    maxTemp=30,
                    minWater=100,
                    maxWater=200,
                )
            )
        case 1:
            # frijol
            return schema.Returnable(
                monthly=[
                    schema.MonthData(
                        humidity=10,
                        waterfall=10,
                        temperature=10,
                        growthPercentage=10,
                        growthEffectiveness=20,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=20,
                        waterfall=20,
                        temperature=20,
                        growthPercentage=20,
                        growthEffectiveness=20,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=30,
                        temperature=30,
                        growthPercentage=30,
                        growthEffectiveness=30,
                        growthHeight=100,
                    ),
                ],
                crop=schema.CropData(
                    x=0.5,
                    y=0.5,
                    minHumidity=50,
                    maxHumidity=60,
                    minTemp=15,
                    maxTemp=30,
                    minWater=100,
                    maxWater=200,
                )
            )
        case 2:
            # sorbo
            return schema.Returnable(
                monthly=[
                    schema.MonthData(
                        humidity=10,
                        waterfall=10,
                        temperature=10,
                        growthPercentage=10,
                        growthEffectiveness=20,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=20,
                        waterfall=20,
                        temperature=20,
                        growthPercentage=20,
                        growthEffectiveness=20,
                        growthHeight=100,
                    ),
                    schema.MonthData(
                        humidity=30,
                        waterfall=30,
                        temperature=30,
                        growthPercentage=30,
                        growthEffectiveness=30,
                        growthHeight=100,
                    ),
                ],
                crop=schema.CropData(
                    x=0.5,
                    y=0.5,
                    minHumidity=50,
                    maxHumidity=60,
                    minTemp=15,
                    maxTemp=30,
                    minWater=100,
                    maxWater=200,
                )
            )
