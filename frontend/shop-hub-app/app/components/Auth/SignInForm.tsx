import AuthForm from "./AuthForm";
import { AuthEnum, type Auth } from "~/models/data";
import { useActionData } from "react-router";
import { useAppDispatch } from "~/state/hooks";
import { setSignIn } from "~/state/slices/authSlice";
import { useNotification } from "../NotificationContext";
import type { AuthResponse } from "~/models/response";

type Props = {
  isOpen: boolean;
  onClose: () => void;
};

const SignInForm = ({ isOpen, onClose }: Props) => {
  const actionData = useActionData<AuthResponse<Auth>>();
  const { showNotification } = useNotification();
  const dispatch = useAppDispatch();

  const onSuccess = () => {
    if (actionData?.isSuccess) {
      dispatch(setSignIn(actionData.data));
      showNotification("Successful login!", "success");
    }
  };

  return (
    <AuthForm
      type={AuthEnum.SignIn}
      title={"Sign In"}
      isOpen={isOpen}
      actionData={actionData}
      onSuccess={onSuccess}
      onClose={onClose}
    />
  );
};

export default SignInForm;
