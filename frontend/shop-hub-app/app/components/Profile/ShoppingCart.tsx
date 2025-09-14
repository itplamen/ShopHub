import { Box, List, ListItem, Menu, MenuItem, Typography } from "@mui/material";
import { useAppSelector } from "~/state/hooks";
import ShoppingCartItem from "./ShoppingCartItem";
import type { Auth } from "~/models/data";

type Props = {
  anchorEl: HTMLElement | null;
  isOpen: boolean;
  onClose: () => void;
};

const ShoppingCart = ({ anchorEl, isOpen, onClose }: Props) => {
  const user: Auth = useAppSelector((state) => state.auth.user);
  const items = useAppSelector(
    (state) => state.shoppingCart.carts[user.userId]
  );

  return (
    <Menu
      anchorEl={anchorEl}
      id="account-menu"
      open={isOpen}
      onClose={onClose}
      slotProps={{
        paper: {
          elevation: 0,
          sx: {
            overflow: "visible",
            filter: "drop-shadow(0px 2px 8px rgba(0,0,0,0.32))",
            mt: 1.5,
            "& .MuiAvatar-root": {
              width: 32,
              height: 32,
              ml: -0.5,
              mr: 1,
            },
            "&::before": {
              content: '""',
              display: "block",
              position: "absolute",
              top: 0,
              right: 14,
              width: 10,
              height: 10,
              bgcolor: "background.paper",
              transform: "translateY(-50%) rotate(45deg)",
              zIndex: 0,
            },
          },
        },
      }}
      transformOrigin={{ horizontal: "right", vertical: "top" }}
      anchorOrigin={{ horizontal: "right", vertical: "bottom" }}
    >
      <Box
        sx={{ flexGrow: 1, maxWidth: 752, maxHeight: 400, overflow: "auto" }}
      >
        <List>
          {items?.length > 0 ? (
            items.map((x) => (
              <ShoppingCartItem
                key={x.id}
                id={x.id}
                name={x.name}
                price={x.price}
                quantity={x.quantity}
              />
            ))
          ) : (
            <ListItem>
              <Typography>No items in the cart</Typography>
            </ListItem>
          )}
        </List>
      </Box>
    </Menu>
  );
};

export default ShoppingCart;
