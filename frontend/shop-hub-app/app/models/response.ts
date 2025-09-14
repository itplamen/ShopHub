import type { AuthType } from "./data";

export interface ApiResponse<TData> {
  isSuccess: boolean;
  errors: string[];
  data: TData;
}

export interface NotificationResponse {
  message?: string;
  createdOn?: Date;
}

export interface AuthResponse<TData>
  extends ApiResponse<TData>,
    NotificationResponse {
  authType: AuthType;
}
