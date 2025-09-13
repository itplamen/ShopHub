import { createSlice, type PayloadAction } from "@reduxjs/toolkit";
import type { Auth } from "~/models/data";

interface AuthState {
  auth: Auth;
}

const initialState: AuthState = {
  auth: {
    userId: 0,
    username: "",
    fullName: "",
    token: "",
    expiresIn: 0,
    refreshToken: "",
  },
};

const authSlice = createSlice({
  name: "authentication",
  initialState,
  reducers: {
    setSignIn: (state, action: PayloadAction<Auth>) => {
      state.auth = action.payload;
    },
  },
});

export const { setSignIn } = authSlice.actions;

export default authSlice.reducer;
