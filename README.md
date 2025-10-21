# Full-stack shop demo built with ASP.NET and React

---

## How to Run Locally

### Backend (.NET 8 Web API)

1. **Configure Database**  
   - Edit `backend/appsettings.Development.json` and set your SQL Server connection string.

2. **Apply Migrations & Seed Data**  
   ```sh
   cd backend
   dotnet ef database update
   ```
   This will create the database and seed sample users/products automatically.

3. **Run the API**  
   ```sh
   dotnet run
   ```
   The API will be available at `https://localhost:5001` (or as configured).

---

### Frontend (React 18 + TypeScript)

1. **Install Dependencies**  
   ```sh
   cd frontend
   npm install
   ```

2. **Configure API URL**  
   - Set `VITE_API_URL` in `frontend/.env` to your backend URL (e.g., `https://localhost:5001`).

3. **Run the Frontend**  
   ```sh
   npm run dev
   ```
   The app will be available at `http://localhost:5173`.

---

## Architecture Decisions & Trade-offs

- **Cart Persistence:**  
  Used `localStorage` for cart persistence. This is simple, reliable, and avoids backend session complexity for a minimal demo. For production, a backend/session-based cart would be considered.

- **State Management:**  
  Used React state/hooks for all state. This is sufficient for a small app and keeps the codebase simple. For larger apps, Context or Redux would be considered.

- **Paging/Infinite Scroll:**  
  Backend exposes paged product endpoints; frontend implements infinite scroll for a modern UX. This approach is scalable and user-friendly.

- **Error Handling:**  
  Backend returns structured JSON errors with proper status codes. Frontend displays clear, user-friendly messages.

- **Extensibility:**  
  Backend is layered (Controllers → Services → Repos → DTOs/Models), making it easy to add features (e.g., more notification types, product management). The codebase is organized for maintainability and future growth.

---

## What’s Next (with More Time)

- Add user registration and password hashing
- Add more comprehensive unit and integration tests.
- Add responsive/mobile styles.
- Update the UI to include more styling
- Improve the UX by adding sounds, animations

---

## Optional: API Testing

- **Unit Tests:**  
  Minimal unit tests are included for the notification controller (`backend.Tests/ControllerTests/NotificationsControllerTests.cs`).  
  ```sh
  cd backend.Tests
  dotnet test
  ```

- **OpenAPI/Swagger:**  
  You can enable Swagger in `Program.cs` for interactive API docs.

---
