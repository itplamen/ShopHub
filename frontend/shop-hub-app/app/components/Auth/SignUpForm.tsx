import AuthForm from "./AuthForm";
import { AuthEnum } from "~/models/data";
import { TextField } from "@mui/material";
import { useActionData } from "react-router";
import { useNotification } from "../NotificationContext";

type Props = {
  isOpen: boolean;
  handleClose: () => void;
};

const SignUpForm = ({ isOpen, handleClose }: Props) => {
  const actionData = useActionData<ApiResponse<string>>();
  const { showNotification } = useNotification();

  const handleSuccess = () => {
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
      handleSuccess={handleSuccess}
      handleClose={handleClose}
    >
      <TextField label="Full Name" name="fullName" type="text" fullWidth />
    </AuthForm>
  );
};

export default SignUpForm;
