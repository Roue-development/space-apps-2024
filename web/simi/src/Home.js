import { Container, TextField } from "@mui/material";
import { Taskbar } from "./modules/Taskbar";
import App from "./App";
import Center from "./Center.js";

export default function Home() {
  return (
    <a>
      <Taskbar/>
      <Center/>
    </a>
  );
}