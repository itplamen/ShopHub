import type { Route } from "./+types/home";
import { Container, Grid, Typography } from "@mui/material";
import { useState, useEffect, useRef } from "react";
import { type Product } from "~/models/data";
import ProductItem from "~/components/Product/ProductItem";

export const meta = ({}: Route.MetaArgs) => {
  return [{ title: "ShopHub" }];
};

const ITEMS_PER_PAGE = 9;

const Home = ({ loaderData }: Route.ComponentProps) => {
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

      if (data.length < ITEMS_PER_PAGE) {
        setHasMore(false);
      }

      setProducts((prev) => [...prev, ...data]);
    } catch (err) {
      console.error("Fetch failed:", err);
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

  if (!loading && (!products || products.length === 0)) {
    return (
      <Container>
        <Typography>No products available.</Typography>
      </Container>
    );
  }

  return (
    <>
      <Container sx={{ paddingY: 1 }}>
        <Grid container spacing={3}>
          {products.map((product: Product) => (
            <ProductItem product={product} key={product.id} />
          ))}
        </Grid>

        {loading && <Typography>Loading products...</Typography>}
        {!loading && products.length === 0 && (
          <Typography>No products available.</Typography>
        )}

        <div ref={loaderRef} style={{ height: 40 }} />
      </Container>
    </>
  );
};

export default Home;
