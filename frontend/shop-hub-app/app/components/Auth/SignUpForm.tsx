import AuthForm from "./AuthForm";
import { AuthEnum } from "~/models/data";
import { TextField } from "@mui/material";
import { useActionData } from "react-router";
import { useNotification } from "../NotificationContext";
import type { AuthResponse } from "~/models/response";

type Props = {
  isOpen: boolean;
  onClose: () => void;
};

const SignUpForm = ({ isOpen, onClose }: Props) => {
  const actionData = useActionData<AuthResponse<string>>();
  const { showNotification } = useNotification();

  const onSuccess = () => {
    if (actionData?.isSuccess) {
      showNotification(
        "Successful registration! Please, sign in to your account",
        "success"
      );
    }
  };

  return (
    <AuthForm
      type={AuthEnum.SignUp}
      title={"Sign Up"}
      isOpen={isOpen}
      actionData={actionData}
      onSuccess={onSuccess}
      onClose={onClose}
    >
      <TextField label="Full Name" name="fullName" type="text" fullWidth />
      <TextField label="Age" name="age" type="number" fullWidth />
      <TextField label="City" name="city" type="text" fullWidth />
    </AuthForm>
  );
};

export default SignUpForm;
