import { IconButton } from "@mui/material";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";

type Props = {
  onClick: () => void;
};

const AddToCart = ({ onClick }: Props) => {
  return (
    <IconButton onClick={onClick} aria-label="Add to cart">
      <ShoppingCartIcon fontSize="large" />
    </IconButton>
  );
};

export default AddToCart;
