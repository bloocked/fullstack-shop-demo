import { useState } from "react"
import { Box, TextField, Button, Typography } from '@mui/material';

const apiUrl = import.meta.env.VITE_API_URL;

function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

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
      // Save user info (e.g., localStorage) and redirect as needed
    } catch (err) {
      setError('Network error');
    }
  };

  return (
    <Box
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
      width="100vw"
      height="100vh"
      bgcolor="#1d1d1dff"
    >
      <Typography variant="h4" mb={3} align="center" sx={{ color: '#fff' }}>
        Welcome!
      </Typography>
      { /* Login form */}
      <form onSubmit={handleSubmit} style={{ width: '100%', maxWidth: 400 }}>
        <TextField
          label="Username"
          variant="filled"
          fullWidth
          margin="normal"
          value={username}
          onChange={e => setUsername(e.target.value)}
          required
            sx={{
              input: { color: '#ffffffff', backgroundColor: '#585858ff' },
              label: { color: '#ffffffff' },
              '.MuiFilledInput-root': { backgroundColor: '#585858ff' }
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
              input: { color: '#ffffffff', backgroundColor: '#585858ff' },
              label: { color: '#ffffffff' },
              '.MuiFilledInput-root': { backgroundColor: '#585858ff' }
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
          sx={{ mt: 2 }}
        >
          Login
        </Button>
      </form>
    </Box>
  );
}
export default Login