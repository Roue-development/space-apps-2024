import { Container, TextField } from "@mui/material";

export default function Center () {
  return (
    <Container sx={{ margin: 0, border: 0, padding: 0, bgcolor: '#a3b7ca', height: '90vh', maxWidth: '100%', display: "flex", justifyContent: "center", alignItems: "center" }}>
      <TextField id="estado" label="Estado:" variant="filled"/>
    </Container>
  );
}