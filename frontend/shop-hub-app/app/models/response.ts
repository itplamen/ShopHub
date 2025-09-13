import type { AuthType } from "./data";

export interface ApiResponse<TData> {
  isSuccess: boolean;
  errors: string[];
  data: TData;
}

export interface AuthResponse<TData> extends ApiResponse<TData> {
  type: AuthType;
}
