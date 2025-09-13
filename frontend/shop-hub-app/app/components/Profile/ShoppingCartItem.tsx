import {
  Avatar,
  IconButton,
  ListItem,
  ListItemAvatar,
  ListItemText,
} from "@mui/material";
import EuroIcon from "@mui/icons-material/Euro";
import DeleteIcon from "@mui/icons-material/Delete";
import { useAppDispatch } from "~/state/hooks";
import { removeFromCart } from "~/state/slices/shoppingCartSlice";

type Props = {
  id: number;
  name: string;
  price: number;
  quantity: number;
};

const ShoppingCartItem = ({ id, name, price, quantity }: Props) => {
  const dispatch = useAppDispatch();
  const handleClick = () => dispatch(removeFromCart(id));

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
