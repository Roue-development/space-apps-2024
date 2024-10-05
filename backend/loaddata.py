import h5py
import xarray as xr
import pandas as pd

ds = xr.open_dataset('data/MERRA2_400.tavg1_2d_slv_Nx.20240901.nc4')
df = ds.to_dataframe()

print(df)


file_path = "data/GEDI04_A_2023075201011_O24115_04_T08796_02_003_01_V002.h5"
hdf = h5py.File(file_path, "r")
print(list(hdf.keys()))
