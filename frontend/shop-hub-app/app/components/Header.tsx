import { Link } from "react-router";
import { AuthEnum, type Auth, type AuthType } from "~/models/data";
import { AppBar, Toolbar, Typography, Button, Box } from "@mui/material";
import { useAppSelector } from "~/state/hooks";
import UserProfile from "./Profile/UserProfile";

type Props = {
  handleOpen: (auth: AuthType) => void;
};

const Header = ({ handleOpen }: Props) => {
  const user: Auth = useAppSelector((state) => state.auth.user);

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" component={Link} to="/" sx={{ flexGrow: 1 }}>
          ShopHub
        </Typography>
        {user && user.username ? (
          <UserProfile />
        ) : (
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
        )}
      </Toolbar>
    </AppBar>
  );
};

export default Header;
