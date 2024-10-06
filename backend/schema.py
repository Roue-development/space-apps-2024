from pydantic import BaseModel
import datetime

class MonthData(BaseModel):
    humidity: float
    '''Un valor del 0 al 100 conteniendo la humedad'''
    waterfall: float
    '''La cantidad de litros de lluvia esperados'''
    temperature: float
    '''La temperatura en grados C'''

    growthPercentage: float
    '''El porcentaje (0 a 100) de crecimiento de la planta'''
    growthEffectiveness: float = 100
    '''Que tan effectivo va a ser el crecimiento bajo las condiciones presentes'''
    growthHeight: float
    '''Los cm que se espera que la planta este en este punto'''

class CropData(BaseModel):
    x: float
    y: float

    minHumidity: float
    maxHumidity: float

    minTemp: float
    maxTemp: float

    minWater: float
    maxWater: float

class Returnable(BaseModel):
    monthly: list[MonthData]
    '''Una lista de los reportes mensuales'''
    crop: CropData
    '''La info basica sobre la planta'''

class AskFordata(BaseModel):
    startDate: datetime.date
    cropID: int
    latitud: float
    longitude: float