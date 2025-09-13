interface SignUpRequest {
  username: string;
  password: string;
  fullName: string;
}

interface SignInRequest {
  username: string;
  password: string;
  deviceId: string;
  deviceName: string;
}
