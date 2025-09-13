const post = async <TRequest, TResponse>(
  url: string,
  body: TRequest
): Promise<ApiResponse<TResponse>> => {
  try {
    const response = await fetch(url, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(body),
    });

    const errorData = await response.json();
    return errorData;
  } catch (error: unknown) {
    let message: string;

    if (error instanceof Error) {
      message = error.message;
    } else if (error && typeof error === "object" && "message" in error) {
      message = String(error.message);
    } else if (typeof error === "string") {
      message = error;
    } else {
      message = "Unknown error";
    }

    return {
      isSuccess: false,
      errors: [message],
      data: null as TResponse,
    };
  }
};

export { post };
