import { configureStore, combineReducers } from "@reduxjs/toolkit";
import { persistStore, persistReducer } from "redux-persist";

import authReducer from "./slices/authSlice";
import shoppingCartReducer from "./slices/shoppingCartSlice";
import storage from "./storage";

const persistConfig = {
  key: "root",
  storage,
  whitelist: ["auth", "shoppingCart"],
};

const rootReducer = combineReducers({
  auth: authReducer,
  shoppingCart: shoppingCartReducer,
});

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export const persistor = persistStore(store);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
