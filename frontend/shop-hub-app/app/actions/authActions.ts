import { post } from "~/api/shopHubApi";
import type { Auth } from "~/models/data";

const deviceId = "1";
const deviceName = "web";

const signUp = async (
  url: string,
  username: string,
  password: string,
  fullName: string
): Promise<ApiResponse<string>> => {
  const request: SignUpRequest = {
    username,
    password,
    fullName,
  };
  const response = await post<SignUpRequest, string>(url, request);

  return response;
};

const signIn = async (
  url: string,
  username: string,
  password: string
): Promise<ApiResponse<Auth>> => {
  const request: SignInRequest = {
    username,
    password,
    deviceId,
    deviceName,
  };

  const response = await post<SignInRequest, Auth>(url, request);
  return response;
};

export { signUp, signIn };
