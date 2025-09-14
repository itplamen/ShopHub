import {
  createSelector,
  createSlice,
  type PayloadAction,
} from "@reduxjs/toolkit";
import type { Product, ShoppingCartItem } from "~/models/data";
import type { RootState } from "../store";

const MIN_ITEM_COUNT: number = 1;

interface ShoppingCart {
  carts: Record<number, ShoppingCartItem[]>;
}

const initialState: ShoppingCart = {
  carts: [],
};

const shoppingCartSlice = createSlice({
  name: "shoppingCart",
  initialState,
  reducers: {
    addToCart: (
      state,
      action: PayloadAction<{ userId: number; product: Product }>
    ) => {
      const { userId, product } = action.payload;

      if (!state.carts[userId]) {
        state.carts[userId] = [];
      }

      const newCartItem: ShoppingCartItem = {
        id: product.id,
        name: product.name,
        price: product.price,
        quantity: 1,
      };

      const cartItem = state.carts[userId].find((x) => x.id === newCartItem.id);
      if (cartItem) {
        state.carts[userId] = state.carts[userId].map((x) =>
          x.id === cartItem.id
            ? { ...x, quantity: x.quantity + newCartItem.quantity }
            : x
        );
      } else {
        state.carts[userId].push(newCartItem);
      }
    },
    removeFromCart: (
      state,
      action: PayloadAction<{ userId: number; productId: number }>
    ) => {
      const { userId, productId } = action.payload;

      const cartItem = state.carts[userId].find((x) => x.id === productId);

      if (cartItem) {
        if ((cartItem?.quantity ?? 0) === MIN_ITEM_COUNT) {
          state.carts[userId] = state.carts[userId].filter(
            (x) => x.id !== cartItem.id
          );
        } else {
          state.carts[userId] = state.carts[userId].map((x) =>
            x.id === cartItem.id ? { ...x, quantity: x.quantity - 1 } : x
          );
        }
      }
    },
  },
});

const totalCartItems = (userId: number) =>
  createSelector(
    (state: RootState) => state.shoppingCart.carts[userId] ?? [],
    (items) => items.reduce((sum, item) => sum + item.quantity, 0)
  );

export const { addToCart, removeFromCart } = shoppingCartSlice.actions;
export { totalCartItems };
export default shoppingCartSlice.reducer;
