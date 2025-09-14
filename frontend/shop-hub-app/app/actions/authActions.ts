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

const deviceId = "1";
const deviceName = "web";

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
    "http://localhost:5041/api/auth/register",
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
    deviceId,
    deviceName,
  };

  const response = await postData<SignInRequest, Auth>(
    "http://localhost:5041/api/auth/login",
    request
  );

  if (response.isSuccess) {
    const notification: ApiResponse<NotificationResponse> =
      await getData<NotificationResponse>(
        "http://localhost:5041/api/notifications",
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
    "http://localhost:5041/api/auth/logout",
    request
  );

  return { ...response, authType: "SignOut" };
};

export { signUp, signIn, signOut };
