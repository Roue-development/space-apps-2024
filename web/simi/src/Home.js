import { Container, TextField } from "@mui/material";
import { Taskbar } from "./modules/Taskbar";

export default function Home() {
  return (
    <a>
      <Taskbar/>
      <Container sx={{ margin: 0, border: 0, padding: 0, bgcolor: '#a3b7ca', height: '90vh', maxWidth: '100%', display: "flex", justifyContent: "center", alignItems: "center" }}>
        <TextField id="estado" label="Estado:" variant="filled"/>
      </Container>
    </a>
  );
}