import { Box, Container, } from "@mui/material";
import Grid from "@mui/material/Grid2";

export default function App () {
  return (
    <Grid container spacing={2} sx={{ margin: 0, border: 0, padding: 0, height: '90vh', maxWidth: '100%' }}>
      <Grid size={10}>
        GODOT goes here
      </Grid>
      <Grid size={2}>
        <Box sx={{ margin: 0, border: 0, padding: 0, height: '90vh', maxWidth: '100%', bgcolor: '#0000FF'}}>
          a
        </Box>
      </Grid>
    </Grid>
  );
}