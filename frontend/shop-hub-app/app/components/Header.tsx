import { Link } from "react-router";
import { AuthEnum, type AuthType } from "~/models/data";
import { AppBar, Toolbar, Typography, Button, Box } from "@mui/material";

type Props = {
  handleOpen: (auth: AuthType) => void;
};

const Header = ({ handleOpen }: Props) => {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" component={Link} to="/" sx={{ flexGrow: 1 }}>
          ShopHub
        </Typography>
        <Box>
          <Button color="inherit" onClick={() => handleOpen(AuthEnum.SignIn)}>
            Sign In
          </Button>
          <Button
            color="inherit"
            variant="outlined"
            onClick={() => handleOpen(AuthEnum.SignUp)}
          >
            Sign Up
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
