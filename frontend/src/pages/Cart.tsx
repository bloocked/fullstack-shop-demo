// Cart page: shows cart items, allows quantity update/remove, and handles logout
import { useEffect, useState } from 'react';
import { Typography, Card, Box, Button } from '@mui/material';
import { useNavigate, Navigate } from 'react-router-dom';

// Product and CartItem types for type safety
type Product = {
  id: number;
  name: string;
  price: number;
  description: string;
  imageUrl: string;
};

type CartItem = {
  product: Product;
  quantity: number;
  imageUrl: string;
};

function Cart() {
  // Auth guard: redirect to login if not authenticated
  const user = localStorage.getItem('user');
  if (!user) {
    return <Navigate to="/login" replace />;
  }

  const navigate = useNavigate();
  const [cart, setCart] = useState<CartItem[]>([]);

  // Load cart from localStorage on mount and when page becomes visible
  useEffect(() => {
    const loadCart = () => {
      const cartStr = localStorage.getItem('cart');
      if (cartStr) {
        try {
          setCart(JSON.parse(cartStr));
        } catch {
          setCart([]);
        }
      } else {
        setCart([]);
      }
    };
    loadCart();
    const handleVisibility = () => {
      if (document.visibilityState === 'visible') {
        loadCart();
      }
    };
    document.addEventListener('visibilitychange', handleVisibility);
    return () => document.removeEventListener('visibilitychange', handleVisibility);
  }, []);

  // Update quantity for a cart item
  const handleQuantity = (id: number, delta: number) => {
    setCart(prev => {
      const updated = prev.map(item =>
        item.product.id === id
          ? { ...item, quantity: Math.max(1, item.quantity + delta) }
          : item
      );
      localStorage.setItem('cart', JSON.stringify(updated));
      return updated;
    });
  };

  // Remove an item from the cart
  const handleRemove = (id: number) => {
    setCart(prev => {
      const updated = prev.filter(item => item.product.id !== id);
      localStorage.setItem('cart', JSON.stringify(updated));
      return updated;
    });
  };

  // Logout: clear user and cart
  const handleLogout = () => {
    localStorage.removeItem('user');
    localStorage.removeItem('cart');
    window.location.href = '/login';
  };

  const total = cart.reduce((sum, item) => sum + item.product.price * item.quantity, 0);

  return (
    <Box sx={{ minHeight: '100vh', background: '#181818', p: 4 }}>
      {/* Back button top left */}
      <Box sx={{ position: 'fixed', top: 0, left: 0, padding: '85px 140px', zIndex: 10, display: 'flex', flexDirection: 'column', alignItems: 'flex-start' }}>
        <Typography
          variant="h3"
          sx={{ fontWeight: 700, fontSize: 80, color: '#fff', cursor: 'pointer', userSelect: 'none', textDecoration: 'underline' }}
          onClick={() => navigate('/home')}
        >
          Back
        </Typography>
      </Box>
      {/* Logout button top right */}
      <div style={{ position: 'fixed', top: 0, right: 0, padding: '85px 140px', zIndex: 10 }}>
        <Typography
          variant="h5"
          sx={{ fontWeight: 700, fontSize: 60, color: '#fff', cursor: 'pointer', mt: 2, textDecoration: 'underline' }}
          onClick={handleLogout}
        >
          Logout
        </Typography>
      </div>
      <Typography variant="h3" sx={{ color: '#fff', fontWeight: 700, fontSize: 100, mb: 4 }}>
        Products
      </Typography>
      {/* Cart content or empty state */}
      {cart.length === 0 ? (
        <Box sx={{ width: '100%', display: 'flex', justifyContent: 'center', mt: 2 }}>
          <Box sx={{ width: 720, maxWidth: '100%', mx: 'auto', minHeight: 180, display: 'flex', alignItems: 'center', justifyContent: 'center', background: 'transparent' }}>
            <Typography variant="h5" sx={{ color: '#bbb' }}>
              Cart is empty :(
            </Typography>
          </Box>
        </Box>
      ) : (
        <Box sx={{ width: '100%', display: 'flex', justifyContent: 'center', mt: 2 }}>
          <Box sx={{ width: 720, maxWidth: '100%', mx: 'auto' }}>
            {/* Cart total */}
            <Box sx={{ width: '100%', display: 'flex', justifyContent: 'flex-end', mb: 2 }}>
              <Typography variant="h5" sx={{ color: '#fff', fontWeight: 700 }}>
                Total: ${total}
              </Typography>
            </Box>
            {/* Cart items */}
            <Box sx={{ display: 'flex', flexDirection: 'column', gap: 3 }}>
              {cart.map(item => (
                <Card key={item.product.id} sx={{ width: '100%', minHeight: 100, background: '#232323', color: '#fff', display: 'flex', alignItems: 'center', px: 4, py: 2, boxSizing: 'border-box' }}>
                  <img
                    src={item.product.imageUrl}
                    alt={item.product.name}
                    style={{ width: 64, height: 64, objectFit: 'cover', borderRadius: 8, marginRight: 24 }}
                  />
                  <Box sx={{ flex: 1, display: 'flex', flexDirection: 'column', alignItems: 'flex-start' }}>
                    <Typography variant="h6" sx={{ color: '#fff' }}>{item.product.name}</Typography>
                    <Typography variant="body2" sx={{ color: '#bbb' }}>{item.product.description}</Typography>
                  </Box>
                  <Box sx={{ display: 'flex', alignItems: 'center', gap: 2, ml: 'auto' }}>
                    <Typography sx={{ color: '#90caf9', fontWeight: 700, minWidth: 90, textAlign: 'right' }}>
                      ${item.product.price * item.quantity}
                    </Typography>
                    <Button variant="outlined" size="small" sx={{ minWidth: 36, color: '#fff', borderColor: '#90caf9' }} onClick={() => handleQuantity(item.product.id, -1)}>-</Button>
                    <Typography sx={{ mx: 1, minWidth: 32, textAlign: 'center', color: '#fff' }}>{item.quantity}</Typography>
                    <Button variant="outlined" size="small" sx={{ minWidth: 36, color: '#fff', borderColor: '#90caf9' }} onClick={() => handleQuantity(item.product.id, 1)}>+</Button>
                    <Button variant="text" color="error" sx={{ ml: 2 }} onClick={() => handleRemove(item.product.id)}>Remove</Button>
                  </Box>
                </Card>
              ))}
            </Box>
          </Box>
        </Box>
      )}
    </Box>
  );
}
export default Cart;