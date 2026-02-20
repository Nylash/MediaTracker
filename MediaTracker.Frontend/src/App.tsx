import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import AddMediaPage from "./pages/AddMediaPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/add" element={<AddMediaPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;