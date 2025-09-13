import AuthForm from "./AuthForm";
import { AuthEnum, type Auth } from "~/models/data";
import { useActionData } from "react-router";
import { useAppDispatch } from "~/state/hooks";
import { setSignIn } from "~/state/slices/authSlice";
import { useNotification } from "../NotificationContext";

type Props = {
  isOpen: boolean;
  handleClose: () => void;
};

const SignInForm = ({ isOpen, handleClose }: Props) => {
  const actionData = useActionData<ApiResponse<Auth>>();
  const { showNotification } = useNotification();
  const dispatch = useAppDispatch();

  const handleSuccess = () => {
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
      handleSuccess={handleSuccess}
      handleClose={handleClose}
    />
  );
};

export default SignInForm;
