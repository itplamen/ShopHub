export const AuthEnum = {
  SignIn: "SignIn",
  SignUp: "SignUp",
  SignOut: "SignOut",
} as const;

export type AuthType = (typeof AuthEnum)[keyof typeof AuthEnum];
