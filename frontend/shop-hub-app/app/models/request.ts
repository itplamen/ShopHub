export interface SignUpRequest {
  username: string;
  password: string;
  fullName: string;
  age: number;
  city: string;
}

export interface SignInRequest {
  username: string;
  password: string;
  deviceId: string;
  deviceName: string;
}

export interface SignOutRequest {
  refreshToken: string;
}
