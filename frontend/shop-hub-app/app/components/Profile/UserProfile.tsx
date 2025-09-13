import * as React from "react";
import Box from "@mui/material/Box";
import { Button } from "@mui/material";
import ShoppingCartIcon from "./Icons/ShoppingCartIcon";
import AvatarIcon from "./Icons/AvatarIcon";
import ShoppingCart from "./ShoppingCart";
import { useAppSelector } from "~/state/hooks";
import { totalCartItems } from "~/state/slices/shoppingCartSlice";

const UserProfile = () => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const count: number = useAppSelector(totalCartItems);

  const handleClose = () => setAnchorEl(null);
  const handleClick = (event: React.MouseEvent<HTMLElement>) =>
    setAnchorEl(event.currentTarget);

  return (
    <>
      <Box sx={{ display: "flex", alignItems: "center", textAlign: "center" }}>
        <AvatarIcon />
        <ShoppingCartIcon itemsCount={count} onClick={handleClick} />
        <Button color="inherit" variant="outlined">
          Sign Out
        </Button>
      </Box>
      <ShoppingCart
        anchorEl={anchorEl}
        isOpen={anchorEl !== null}
        onClose={handleClose}
      />
    </>
  );
};

export default UserProfile;
