export const AuthEnum = {
  SignIn: "SignIn",
  SignUp: "SignUp",
  SignOut: "SignOut",
} as const;

export type AuthType = (typeof AuthEnum)[keyof typeof AuthEnum];

export interface Auth {
  userId: number;
  username: string;
  fullName: string;
  token: string;
  expiresIn: number;
  refreshToken: string;
}

export interface Product {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
  description: string;
}
