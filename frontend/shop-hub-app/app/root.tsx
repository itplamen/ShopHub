import {
  isRouteErrorResponse,
  Links,
  Meta,
  Outlet,
  Scripts,
  ScrollRestoration,
  type ActionFunctionArgs,
} from "react-router";

import type { Route } from "./+types/root";
import "./app.css";
import { NotificationProvider } from "./components/NotificationContext";
import ReduxProvider from "./components/ReduxProvider";
import Header from "./components/Header";
import SignInForm from "./components/Auth/SignInForm";
import { AuthEnum, type AuthType } from "./models/data";
import { useState } from "react";
import SignUpForm from "./components/Auth/SignUpForm";
import { signIn, signOut, signUp } from "./actions/authActions";

export const links: Route.LinksFunction = () => [
  { rel: "preconnect", href: "https://fonts.googleapis.com" },
  {
    rel: "preconnect",
    href: "https://fonts.gstatic.com",
    crossOrigin: "anonymous",
  },
  {
    rel: "stylesheet",
    href: "https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&display=swap",
  },
];

export const action = async ({ request }: ActionFunctionArgs) => {
  const formData = await request.formData();
  const type = formData.get("type") as AuthType;
  const username = formData.get("username") as string;
  const password = formData.get("password") as string;
  const fullName = formData.get("fullName") as string;
  const age = Number(formData.get("age") as string);
  const city = formData.get("city") as string;
  const refreshToken = formData.get("refreshToken") as string;

  const response =
    type === "SignUp"
      ? await signUp(username, password, fullName, age, city)
      : type === "SignIn"
        ? await signIn(username, password)
        : await signOut(refreshToken);

  return { ...response };
};

export function Layout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <head>
        <meta charSet="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <Meta />
        <Links />
      </head>
      <body>
        {children}
        <ScrollRestoration />
        <Scripts />
      </body>
    </html>
  );
}
type AuthState = AuthType | null;

export default function App() {
  const [open, setOpen] = useState<AuthState>(null);
  const handleOpen = (authType: AuthType) => setOpen(authType);
  const handleClose = () => setOpen(null);

  return (
    <ReduxProvider>
      <NotificationProvider>
        <Header handleOpen={handleOpen} />
        <SignInForm isOpen={open === AuthEnum.SignIn} onClose={handleClose} />
        <SignUpForm isOpen={open === AuthEnum.SignUp} onClose={handleClose} />
        <Outlet />
      </NotificationProvider>
    </ReduxProvider>
  );
}

export function ErrorBoundary({ error }: Route.ErrorBoundaryProps) {
  let message = "Oops!";
  let details = "An unexpected error occurred.";
  let stack: string | undefined;

  if (isRouteErrorResponse(error)) {
    message = error.status === 404 ? "404" : "Error";
    details =
      error.status === 404
        ? "The requested page could not be found."
        : error.statusText || details;
  } else if (import.meta.env.DEV && error && error instanceof Error) {
    details = error.message;
    stack = error.stack;
  }

  return (
    <main className="pt-16 p-4 container mx-auto">
      <h1>{message}</h1>
      <p>{details}</p>
      {stack && (
        <pre className="w-full p-4 overflow-x-auto">
          <code>{stack}</code>
        </pre>
      )}
    </main>
  );
}
