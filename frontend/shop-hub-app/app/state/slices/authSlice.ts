import { createSlice, type PayloadAction } from "@reduxjs/toolkit";
import type { Auth } from "~/models/data";

interface AuthState {
  user: Auth;
}

const initialState: AuthState = {
  user: {
    userId: 0,
    username: "",
    fullName: "",
    age: 0,
    city: "",
    token: "",
    expiresIn: 0,
    refreshToken: "",
  },
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    setSignIn: (state, action: PayloadAction<Auth>) => {
      state.user = action.payload;
    },
    setSignOut: (state) => {
      state.user = {} as Auth;
    },
  },
});

export const { setSignIn, setSignOut } = authSlice.actions;

export default authSlice.reducer;
