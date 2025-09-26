// Home.tsx: Product listing, infinite scroll, notification, and cart logic
// Only essential comments for clarity and maintainability

import { useState, useEffect, useRef } from "react";
import { Grid, Card, CardContent, Typography, Alert, Slide, Button } from "@mui/material";
import { useNavigate, Navigate } from "react-router-dom";

// Product type for type safety
type Product = {
  id: number;
  name: string;
  price: number;
  description: string;
  // Add image or other fields if your backend returns them
};

function Home() {
  // State for user, products, pagination, notification, etc.
  const [username, setUsername] = useState("");
  const [userId, setUserId] = useState<number|null>(null);
  const [products, setProducts] = useState<Product[]>([]);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(false);
  const [hasMore, setHasMore] = useState(true);
  const [notification, setNotification] = useState<string|null>(null);
  const [showBanner, setShowBanner] = useState(false);
  const pageSize = 10;
  const loadingRef = useRef(false);
  const navigate = useNavigate();

  // Auth guard: redirect to login if not authenticated
  const user = localStorage.getItem('user');
  if (!user) {
    return <Navigate to="/login" replace />;
  }

  // Add product to cart and persist in localStorage
  const handleAddToCart = (product: Product) => {
    const cartStr = localStorage.getItem('cart');
    let cart: { product: Product; quantity: number }[] = [];
    if (cartStr) {
      try {
        cart = JSON.parse(cartStr);
      } catch {}
    }
    const idx = cart.findIndex(item => item.product.id === product.id);
    if (idx > -1) {
      cart[idx].quantity += 1;
    } else {
      cart.push({ product, quantity: 1 });
    }
    localStorage.setItem('cart', JSON.stringify(cart));
  };

  // Load user info on mount
  useEffect(() => {
    const userStr = localStorage.getItem("user");
    if (userStr) {
      const user = JSON.parse(userStr);
      setUsername(user.username);
      setUserId(user.id);
    }
  }, []);

  // Show notification banner only after login
  useEffect(() => {
    if (!userId) return;
    const shouldShow = localStorage.getItem('showLoginNotification');
    if (!shouldShow) return;
    fetch(`${import.meta.env.VITE_API_URL}/api/notifications/latest?userId=${userId}`)
      .then(res => res.ok ? res.json() : null)
      .then(data => {
        if (data && data.message) {
          setNotification(data.message);
          setShowBanner(true);
          setTimeout(() => setShowBanner(false), 4000);
        }
        localStorage.removeItem('showLoginNotification');
      });
  }, [userId]);

  // Infinite scroll: load more products on scroll
  useEffect(() => {
    if (!hasMore || loadingRef.current) return;
    setLoading(true);
    loadingRef.current = true;
    fetch(`${import.meta.env.VITE_API_URL}/api/products?page=${page}&pageSize=${pageSize}`)
      .then(res => res.json())
      .then(data => {
        if (Array.isArray(data) && data.length > 0) {
          setProducts(prev => [...prev, ...data]);
          if (data.length < pageSize) setHasMore(false);
        } else {
          setHasMore(false);
        }
      })
      .catch(() => setHasMore(false))
      .finally(() => {
        setLoading(false);
        loadingRef.current = false;
      });
  }, [page]);

  // Listen for scroll to trigger infinite scroll
  useEffect(() => {
    const handleScroll = () => {
      if (!hasMore || loadingRef.current) return;
      const scrollY = window.scrollY || window.pageYOffset;
      const windowHeight = window.innerHeight;
      const docHeight = document.documentElement.scrollHeight;
      if (docHeight - (scrollY + windowHeight) < 5) {
        setPage(prev => prev + 1);
      }
    };
    window.addEventListener('scroll', handleScroll);
    return () => window.removeEventListener('scroll', handleScroll);
  }, [hasMore]);

  // Logout and clear session
  const handleLogout = () => {
    localStorage.removeItem('user');
    localStorage.removeItem('cart');
    navigate('/login');
  };

  return (
    <div style={{ minHeight: '100vh', background: '#181818' }}>
      {/* Notification banner after login */}
      <Slide direction="down" in={showBanner} mountOnEnter unmountOnExit>
        <Alert severity="success" sx={{ position: 'fixed', top: 0, left: 0, right: 0, zIndex: 2000, borderRadius: 0, fontSize: 22, fontWeight: 600 }}>
          {notification}
        </Alert>
      </Slide>
      {/* Username and Cart link top-left */}
      <div style={{ position: 'fixed', top: 0, left: 0, padding: '85px 140px', zIndex: 10, display: 'flex', flexDirection: 'column', alignItems: 'flex-start' }}>
        <Typography variant="h3" sx={{ fontWeight: 700, fontSize: 100, color: '#fff' }}>
          {username}
        </Typography>
        <Typography
          variant="h5"
          sx={{ fontWeight: 700, fontSize: 60, color: '#fff', cursor: 'pointer', mt: 2, textDecoration: 'underline' }}
          onClick={() => navigate('/cart')}
        >
          Cart
        </Typography>
      </div>
      {/* Logout button top-right */}
      <div style={{ position: 'fixed', top: 0, right: 0, padding: '85px 140px', zIndex: 10 }}>
        <Typography
          variant="h5"
          sx={{ fontWeight: 700, fontSize: 60, color: '#fff', cursor: 'pointer', mt: 2, textDecoration: 'underline' }}
          onClick={handleLogout}
        >
          Logout
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
                <Button
                  variant="contained"
                  color="primary"
                  sx={{ m: 2, fontWeight: 700 }}
                  onClick={() => handleAddToCart(product)}
                >
                  Add to Cart
                </Button>
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
        {loading && (
          <Typography align="center" sx={{ color: '#fff', mt: 2 }}>
            Loading more products...
          </Typography>
        )}
      </div>
    </div>
  );
}
export default Home