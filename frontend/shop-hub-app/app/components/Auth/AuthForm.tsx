import {
  Button,
  Dialog,
  DialogContent,
  DialogTitle,
  TextField,
  Typography,
} from "@mui/material";
import type { Auth, AuthType } from "~/models/data";
import { Form } from "react-router";
import { useEffect } from "react";
import type { AuthResponse } from "~/models/response";

type Props = {
  children?: React.ReactNode;
  type: AuthType;
  title: string;
  isOpen: boolean;
  actionData?: AuthResponse<string | Auth>;
  onSuccess: () => void;
  onClose: () => void;
};

const AuthForm = ({
  children,
  type,
  title,
  isOpen,
  actionData,
  onSuccess,
  onClose,
}: Props) => {
  useEffect(() => {
    if (actionData?.isSuccess && actionData.type === type) {
      onSuccess();
      onClose();
    }
  }, [actionData?.isSuccess, actionData?.data, type]);

  const handleCLose = () => {
    if (actionData && actionData.errors) {
      actionData.errors = [];
    }

    onClose();
  };

  return (
    <Dialog open={isOpen} onClose={handleCLose} maxWidth="xs" fullWidth>
      <DialogTitle align="center">{title}</DialogTitle>
      <DialogContent>
        {actionData &&
          !actionData?.isSuccess &&
          actionData?.errors?.length > 0 && (
            <Typography color="error" align="left">
              <ul
                style={{
                  paddingLeft: "1.2em",
                  marginBottom: 10,
                  listStyleType: "disc",
                }}
              >
                {actionData.errors.map((error, idx) => (
                  <li key={idx}>{error}</li>
                ))}
              </ul>
            </Typography>
          )}

        <Form
          method="post"
          style={{ display: "flex", flexDirection: "column", gap: 16 }}
        >
          <input type="hidden" name="type" value={type} />
          <TextField
            label="Username"
            name="username"
            type="text"
            fullWidth
            required
          />
          <TextField
            label="Password"
            name="password"
            type="password"
            fullWidth
            required
          />
          {children}
          <Button type="submit" variant="contained" fullWidth>
            {title}
          </Button>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default AuthForm;
