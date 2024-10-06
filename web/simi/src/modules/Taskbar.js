import { AppBar, Box, ButtonBase, Container, Typography } from "@mui/material";
import SpaceAppLogo from "./SpaceAppLogo.png";
import KinichLogo from "./uwu.png"

export function Taskbar () {
  return (
    <Container sx={{ margin: 0, border: 0, padding: 0, bgcolor: '#000000', height: '10vh', width: 'auto', display:'flex', alignItems: 'center' }}>
      <Container sx={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
        <ButtonBase>
          <img src={SpaceAppLogo} alt="Logo" width="100"/>
        </ButtonBase>
        <ButtonBase>
          <img src={KinichLogo} alt="LogoKinich" width="50"/>
        </ButtonBase>
      </Container>
    </Container>
  );
}