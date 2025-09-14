import Header from "~/components/Header";
import type { Route } from "./+types/home";
import { Container, Grid, Typography } from "@mui/material";
import { useState, useEffect, useRef } from "react";
import type { ActionFunctionArgs } from "react-router";
import { AuthEnum, type AuthType, type Product } from "~/models/data";
import { signUp, signIn, signOut } from "~/actions/authActions";
import SignInForm from "~/components/Auth/SignInForm";
import SignUpForm from "~/components/Auth/SignUpForm";
import ProductItem from "~/components/Product/ProductItem";

export const meta = ({}: Route.MetaArgs) => {
  return [{ title: "ShopHub" }];
};

const action = async ({ request }: ActionFunctionArgs) => {
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

const ITEMS_PER_PAGE = 9;

type AuthState = AuthType | null;

const Home = ({ loaderData }: Route.ComponentProps) => {
  const [open, setOpen] = useState<AuthState>(null);
  const [products, setProducts] = useState<Product[]>([]);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(false);
  const [hasMore, setHasMore] = useState(true);
  const loaderRef = useRef<HTMLDivElement | null>(null);

  const fetchProducts = async (page: number) => {
    try {
      setLoading(true);
      const res = await fetch(
        `http://localhost:5041/api/products?page=${page}&pageSize=${ITEMS_PER_PAGE}`
      );
      if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
      const data: Product[] = await res.json();

      if (data.length < ITEMS_PER_PAGE) setHasMore(false);

      setProducts((prev) => [...prev, ...data]);
    } catch (err) {
      //console.error("Fetch failed:", err);
      setHasMore(false);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchProducts(page);
  }, [page]);

  useEffect(() => {
    if (loading) return;
    const observer = new IntersectionObserver((entries) => {
      if (entries[0].isIntersecting && hasMore) {
        setPage((prev) => prev + 1);
      }
    });
    if (loaderRef.current) observer.observe(loaderRef.current);
    return () => observer.disconnect();
  }, [loading, hasMore]);

  if (!products || products.length === 0) {
    return (
      <Container>
        <Typography>No products available.</Typography>
      </Container>
    );
  }

  const handleOpen = (authType: AuthType) => setOpen(authType);
  const handleClose = () => setOpen(null);

  return (
    <>
      <Header handleOpen={handleOpen} />
      <SignInForm isOpen={open === AuthEnum.SignIn} onClose={handleClose} />
      <SignUpForm isOpen={open === AuthEnum.SignUp} onClose={handleClose} />
      <Container
        sx={{
          paddingY: 1,
        }}
      >
        <Grid container spacing={3}>
          {products.map((product: Product) => (
            <ProductItem product={product} key={product.id} />
          ))}
        </Grid>
        <div ref={loaderRef} style={{ height: 40 }} />
      </Container>
    </>
  );
};

export { action };
export default Home;
