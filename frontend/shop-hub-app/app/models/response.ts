interface ApiResponse<TData> {
  isSuccess: boolean;
  errors: string[];
  data: TData;
}
