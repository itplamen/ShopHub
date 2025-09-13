import {
  createSelector,
  createSlice,
  type PayloadAction,
} from "@reduxjs/toolkit";
import type { Product, ShoppingCartItem } from "~/models/data";
import type { RootState } from "../store";

const MIN_ITEM_COUNT: number = 1;

interface ShoppingCart {
  items: ShoppingCartItem[];
}

const initialState: ShoppingCart = {
  items: [],
};

const shoppingCartSlice = createSlice({
  name: "shoppingCart",
  initialState,
  reducers: {
    addToCart: (state, action: PayloadAction<Product>) => {
      const newCartItem: ShoppingCartItem = {
        id: action.payload.id,
        name: action.payload.name,
        price: action.payload.price,
        quantity: 1,
      };

      const cartItem = state.items.find((x) => x.id === newCartItem.id);
      if (cartItem) {
        state.items = state.items.map((x) =>
          x.id === cartItem.id
            ? { ...x, quantity: x.quantity + newCartItem.quantity }
            : x
        );
      } else {
        state.items.push(newCartItem);
      }
    },
    removeFromCart: (state, action: PayloadAction<number>) => {
      const cartItem = state.items.find((x) => x.id === action.payload);

      if (cartItem) {
        if ((cartItem?.quantity ?? 0) === MIN_ITEM_COUNT) {
          state.items = state.items.filter((x) => x.id !== cartItem.id);
        } else {
          state.items = state.items.map((x) =>
            x.id === cartItem.id ? { ...x, quantity: x.quantity - 1 } : x
          );
        }
      }
    },
  },
});

const totalCartItems = createSelector(
  (state: RootState) => state.shoppingCart,
  (shoppingCart) =>
    shoppingCart.items.reduce((sum, item) => sum + item.quantity, 0)
);

export const { addToCart, removeFromCart } = shoppingCartSlice.actions;
export { totalCartItems };
export default shoppingCartSlice.reducer;
