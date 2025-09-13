import { Button } from "@mui/material";
import { useEffect } from "react";
import { Form, useActionData } from "react-router";
import { AuthEnum, type Auth } from "~/models/data";
import type { AuthResponse } from "~/models/response";
import { useAppDispatch, useAppSelector } from "~/state/hooks";
import { setSignOut } from "~/state/slices/authSlice";
import { useNotification } from "../NotificationContext";

const SignOutForm = () => {
  const dispatch = useAppDispatch();
  const { showNotification } = useNotification();
  const user: Auth = useAppSelector((state) => state.auth.user);
  const actionData = useActionData<AuthResponse<boolean>>();

  useEffect(() => {
    console.log("qeqe");
    console.log(actionData);
    if (actionData?.isSuccess && actionData.type === "SignOut") {
      dispatch(setSignOut());
    } else if (!actionData?.isSuccess) {
      showNotification("Could not sign out!", "error");
    }
  }, [actionData?.isSuccess, actionData?.data, actionData?.type]);

  return (
    <Form
      method="post"
      style={{ display: "flex", flexDirection: "column", gap: 16 }}
    >
      <input type="hidden" name="type" value={AuthEnum.SignOut} />
      <input type="hidden" name="refreshToken" value={user.refreshToken} />
      <Button type="submit" color="inherit" variant="outlined">
        Sign Out
      </Button>
    </Form>
  );
};

export default SignOutForm;
