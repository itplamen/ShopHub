import {
  Avatar,
  IconButton,
  ListItem,
  ListItemAvatar,
  ListItemText,
} from "@mui/material";
import EuroIcon from "@mui/icons-material/Euro";
import DeleteIcon from "@mui/icons-material/Delete";
import { useAppDispatch, useAppSelector } from "~/state/hooks";
import { removeFromCart } from "~/state/slices/shoppingCartSlice";
import type { Auth } from "~/models/data";

type Props = {
  id: number;
  name: string;
  price: number;
  quantity: number;
};

const ShoppingCartItem = ({ id, name, price, quantity }: Props) => {
  const user: Auth = useAppSelector((state) => state.auth.user);
  const dispatch = useAppDispatch();
  const handleClick = () =>
    dispatch(removeFromCart({ userId: user.userId, productId: id }));

  return (
    <ListItem
      key={id}
      secondaryAction={
        <IconButton onClick={handleClick} edge="end" aria-label="delete">
          <DeleteIcon />
        </IconButton>
      }
    >
      <ListItemAvatar>
        <Avatar>{quantity}</Avatar>
      </ListItemAvatar>

      <ListItemText
        primary={name}
        secondary={
          <>
            <EuroIcon fontSize="small" />
            {price.toFixed(2)}
          </>
        }
      />
    </ListItem>
  );
};

export default ShoppingCartItem;
