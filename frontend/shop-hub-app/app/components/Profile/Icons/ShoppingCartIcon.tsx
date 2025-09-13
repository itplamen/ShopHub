import { Badge, IconButton, styled, type BadgeProps } from "@mui/material";
import ShoppingCart from "@mui/icons-material/ShoppingCart";

const StyledBadge = styled(Badge)<BadgeProps>(({ theme }) => ({
  "& .MuiBadge-badge": {
    right: -3,
    top: 13,
    border: `2px solid ${(theme.vars ?? theme).palette.background.paper}`,
    padding: "0 4px",
  },
}));

type Props = {
  itemsCount: number;
  onClick: (event: React.MouseEvent<HTMLElement>) => void;
};

const ShoppingCartIcon = ({ itemsCount, onClick }: Props) => {
  return (
    <IconButton onClick={onClick} size="large" sx={{ marginRight: 3 }}>
      <StyledBadge badgeContent={itemsCount} color="secondary">
        <ShoppingCart fontSize="large" />
      </StyledBadge>
    </IconButton>
  );
};

export default ShoppingCartIcon;
