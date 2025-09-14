import * as React from "react";
import Box from "@mui/material/Box";
import ShoppingCartIcon from "./Icons/ShoppingCartIcon";
import AvatarIcon from "./Icons/AvatarIcon";
import ShoppingCart from "./ShoppingCart";
import { useAppSelector } from "~/state/hooks";
import { totalCartItems } from "~/state/slices/shoppingCartSlice";
import type { Auth } from "~/models/data";

const UserProfile = () => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const user: Auth = useAppSelector((state) => state.auth.user);
  const count: number = useAppSelector(totalCartItems(user.userId));
  const handleClose = () => setAnchorEl(null);
  const handleClick = (event: React.MouseEvent<HTMLElement>) =>
    setAnchorEl(event.currentTarget);

  return (
    <>
      <Box sx={{ display: "flex", alignItems: "center", textAlign: "center" }}>
        <AvatarIcon />
        <ShoppingCartIcon itemsCount={count} onClick={handleClick} />
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
