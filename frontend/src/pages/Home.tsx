import { useState, useEffect } from "react";
import { Grid, Card, CardContent, Typography } from "@mui/material";

type Product = {
  id: number;
  name: string;
  price: number;
  description: string;
  // Add image or other fields if your backend returns them
};

function Home() {
  const [username, setUsername] = useState("");
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    const userStr = localStorage.getItem("user");
    if (userStr) {
      const user = JSON.parse(userStr);
      setUsername(user.username);
    }
    // Fetch products from backend with page and pageSize
    fetch(`${import.meta.env.VITE_API_URL}/api/products?page=1&pageSize=20`)
      .then(res => res.json())
      .then(data => setProducts(data))
      .catch(() => setProducts([]));
  }, []);

  return (
    <div style={{ minHeight: '100vh', background: '#181818' }}>
      {/* Username top-left */}
      <div style={{ position: 'fixed', top: 0, left: 0, padding: '32px 48px', zIndex: 10 }}>
        <Typography variant="h3" sx={{ fontWeight: 700, color: '#fff' }}>
          {username}
        </Typography>
      </div>
      {/* Product grid with 4 per row */}
  <div style={{ width: '100%', paddingTop: 80, boxSizing: 'border-box' }}>
  <Grid container spacing={3} justifyContent="center">
          {products.map(product => (
            // @ts-ignore
            <Grid item xs={3} key={product.id}>
              <Card sx={{ width: 280, height: 320, display: 'flex', flexDirection: 'column', justifyContent: 'space-between', background: '#232323', color: '#fff' }}>
                <CardContent sx={{ flexGrow: 1 }}>
                  <Typography variant="h6" sx={{ mb: 1, color: '#fff' }}>{product.name}</Typography>
                  <Typography sx={{ mb: 1, color: '#90caf9' }}>${product.price}</Typography>
                  <Typography variant="body2" sx={{ color: '#bbb' }}>{product.description}</Typography>
                </CardContent>
              </Card>
            </Grid>
          ))}
          {/* Add empty grid items to fill the last row if needed */}
          {(() => {
            const itemsPerRow = 4;
            const remainder = products.length % itemsPerRow;
            const emptySlots = remainder === 0 ? 0 : itemsPerRow - remainder;
            return Array.from({ length: emptySlots }).map((_, idx) => (
              // @ts-ignore
              <Grid item xs={3} key={`empty-${idx}`} />
            ));
          })()}
        </Grid>
      </div>
    </div>
  );
}
export default Home