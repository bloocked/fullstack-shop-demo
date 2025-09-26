import { useState, useEffect, useRef } from "react";
import { Grid, Card, CardContent, Typography, Alert, Slide } from "@mui/material";
import { useNavigate } from "react-router-dom";

type Product = {
  id: number;
  name: string;
  price: number;
  description: string;
  // Add image or other fields if your backend returns them
};

function Home() {
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

  useEffect(() => {
    const userStr = localStorage.getItem("user");
    if (userStr) {
      const user = JSON.parse(userStr);
      setUsername(user.username);
      setUserId(user.id);
    }
  }, []);

  // Show notification banner only if showLoginNotification flag is set
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

  useEffect(() => {
    const handleScroll = () => {
      if (!hasMore || loadingRef.current) return;

      const scrollY = window.scrollY || window.pageYOffset;
      const windowHeight = window.innerHeight;
      const docHeight = document.documentElement.scrollHeight;

      if (docHeight - (scrollY + windowHeight) < 5) { // intentionally small margin to showcase infinite scroll working
        setPage(prev => prev + 1);
      }
    };

    window.addEventListener('scroll', handleScroll);

    return () => window.removeEventListener('scroll', handleScroll);
  }, [hasMore]);

  return (
    <div style={{ minHeight: '100vh', background: '#181818' }}>
      {/* Notification banner */}
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