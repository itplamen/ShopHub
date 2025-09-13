interface BaseItem {
  id: number;
  name: string;
  price: number;
}

interface UserProfile {
  username: string;
  fullName: string;
  age: number;
  city: string;
}

export const AuthEnum = {
  SignIn: "SignIn",
  SignUp: "SignUp",
  SignOut: "SignOut",
} as const;

export type AuthType = (typeof AuthEnum)[keyof typeof AuthEnum];

export interface Auth extends UserProfile {
  userId: number;
  token: string;
  expiresIn: number;
  refreshToken: string;
}

export interface Product extends BaseItem {
  imageUrl: string;
  description: string;
}

export interface ShoppingCartItem extends BaseItem {
  quantity: number;
}
