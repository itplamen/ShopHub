import {
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";
import EuroIcon from "@mui/icons-material/Euro";
import { useAppDispatch } from "~/state/hooks";
import type { Product } from "~/models/data";
import { addToCart } from "~/state/slices/shoppingCartSlice";
import AddToCart from "./AddToCart";

type Props = {
  product: Product;
};

const ProductItem = ({ product }: Props) => {
  const dispatch = useAppDispatch();
  const handleClick = () => dispatch(addToCart(product));

  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardMedia
        component="img"
        height="140"
        image={`/${product.imageUrl}`}
        alt={product.name}
      />
      <CardContent>
        <Typography
          gutterBottom
          variant="h5"
          component="div"
          sx={{ color: "text.secondary" }}
        >
          {product.name}
        </Typography>
        <Typography
          variant="body2"
          sx={{ color: "text.secondary", height: 50 }}
        >
          {product.description}
        </Typography>
      </CardContent>
      <CardActions
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          px: 2,
        }}
      >
        <Typography sx={{ display: "flex", alignItems: "center" }}>
          <EuroIcon fontSize="small" />
          {product.price.toFixed(2)}
        </Typography>
        <AddToCart onClick={handleClick} />
      </CardActions>
    </Card>
  );
};

export default ProductItem;
