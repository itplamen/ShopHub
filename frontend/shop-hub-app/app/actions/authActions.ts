import { getData, postData } from "~/api/shopHubApi";
import type { Auth } from "~/models/data";
import type {
  SignInRequest,
  SignOutRequest,
  SignUpRequest,
} from "~/models/request";
import type {
  ApiResponse,
  AuthResponse,
  NotificationResponse,
} from "~/models/response";

const DEVICE_ID: string = "1";
const DEVICE_NAME: string = "web";
const API_AUTH_URL: string = import.meta.env.VITE_AUTH_API_URL;

const signUp = async (
  username: string,
  password: string,
  fullName: string,
  age: number,
  city: string
): Promise<AuthResponse<string>> => {
  const request: SignUpRequest = {
    username,
    password,
    fullName,
    age,
    city,
  };
  const response = await postData<SignUpRequest, string>(
    `${API_AUTH_URL}/auth/register`,
    request
  );

  if (response.isSuccess) {
    return {
      authType: "SignUp",
      isSuccess: true,
      errors: [],
      message: "Successful registration! Please, sign in to your account",
      data: "",
    };
  }

  return {
    authType: "SignUp",
    ...response,
  };
};

const signIn = async (
  username: string,
  password: string
): Promise<AuthResponse<Auth>> => {
  const request: SignInRequest = {
    username,
    password,
    deviceId: DEVICE_ID,
    deviceName: DEVICE_NAME,
  };

  const response = await postData<SignInRequest, Auth>(
    `${API_AUTH_URL}/auth/login`,
    request
  );

  if (response.isSuccess) {
    const notification: ApiResponse<NotificationResponse> =
      await getData<NotificationResponse>(
        `${API_AUTH_URL}/notifications`,
        response.data.token
      );

    return {
      authType: "SignIn",
      isSuccess: true,
      errors: [],
      ...notification.data,
      data: {
        ...response.data,
      },
    };
  }

  return {
    authType: "SignIn",
    ...response,
  };
};

const signOut = async (
  refreshToken: string
): Promise<AuthResponse<boolean>> => {
  const request: SignOutRequest = {
    refreshToken,
  };

  const response = await postData<SignOutRequest, boolean>(
    `${API_AUTH_URL}/auth/logout`,
    request
  );

  return { ...response, authType: "SignOut" };
};

export { signUp, signIn, signOut };
