// Login page: handles user authentication and redirects on success
import { useState } from "react"
import { Box, TextField, Button, Typography, CssBaseline } from '@mui/material';
import { useNavigate } from "react-router-dom";

const apiUrl = import.meta.env.VITE_API_URL;

function Login() {
  // State for username, password, error
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  // Handle login form submit
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    try {
      const response = await fetch(`${apiUrl}/api/users/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password }),
      });
      if (!response.ok) {
        const data = await response.json();
        setError(data.error || 'Login failed');
        return;
      }
      const user = await response.json();
      localStorage.setItem('user', JSON.stringify(user));
      localStorage.setItem('showLoginNotification', '1');
      navigate('/home');
    } catch (err) {
      setError('Network error');
    }
  };

  return (
    <>
      <CssBaseline />
      <style>{`
        html, body { height: 100%; margin: 0; overflow: hidden; background: #1d1d1dff !important; }
      `}</style>
      <Box
        display="flex"
        flexDirection="column"
        justifyContent="center"
        alignItems="center"
        width="100%"
        height="100vh"
        sx={{ overflowX: 'hidden', mb: 20 }}
      >
      <Typography variant="h4" mb={3} align="center" sx={{ color: '#fff' }}>
        Welcome!
      </Typography>
      <form onSubmit={handleSubmit} style={{ width: '100%', maxWidth: 520, margin: 0 }}>
        <TextField
          label="Username"
          variant="filled"
          fullWidth
          margin="normal"
          value={username}
          onChange={e => setUsername(e.target.value)}
          required
          sx={{
            input: { color: '#ffffffff', backgroundColor: '#585858ff', fontSize: 24, height: 64 },
            label: { color: '#ffffffff', fontSize: 22 },
            '.MuiFilledInput-root': { backgroundColor: '#585858ff' },
            mb: 3
          }}
        />
        <TextField
          label="Password"
          type="password"
          variant="filled"
          fullWidth
          margin="normal"
          value={password}
          onChange={e => setPassword(e.target.value)}
          required
          sx={{
            input: { color: '#ffffffff', backgroundColor: '#585858ff', fontSize: 24, height: 64 },
            label: { color: '#ffffffff', fontSize: 22 },
            '.MuiFilledInput-root': { backgroundColor: '#585858ff' },
            mb: 3
          }}
        />
        {error && (
          <Typography color="error" variant="body2">
            {error}
          </Typography>
        )}
        <Button
          type="submit"
          variant="contained"
          color="primary"
          fullWidth
          sx={{ mt: 2, height: 60, fontSize: 24, fontWeight: 600 }}
        >
          LOGIN
        </Button>
      </form>
      </Box>
    </>
  );
}
export default Login