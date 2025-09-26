import { useEffect, useState } from 'react';
import { Typography, Card, CardContent, Box } from '@mui/material';

type Product = {
  id: number;
  name: string;
  price: number;
  description: string;
};

function Cart() {
  const [cart, setCart] = useState<Product[]>([]);

  useEffect(() => {
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
  }, []);

  return (
    <Box sx={{ minHeight: '100vh', background: '#181818', p: 4 }}>
      <Typography variant="h3" sx={{ color: '#fff', fontWeight: 700, mb: 4 }}>
        Products
      </Typography>
      {cart.length === 0 ? (
        <Typography variant="h5" sx={{ color: '#bbb' }}>
          Cart is empty
        </Typography>
      ) : (
        cart.map(product => (
          <Card key={product.id} sx={{ mb: 3, background: '#232323', color: '#fff', maxWidth: 480 }}>
            <CardContent>
              <Typography variant="h6" sx={{ color: '#fff' }}>{product.name}</Typography>
              <Typography sx={{ color: '#90caf9' }}>${product.price}</Typography>
              <Typography variant="body2" sx={{ color: '#bbb' }}>{product.description}</Typography>
            </CardContent>
          </Card>
        ))
      )}
    </Box>
  );
}
export default Cart