import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./layout/Layout";
import HomePage from "./pages/HomePage";
import AddMediaPage from "./pages/AddMediaPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/add" element={<AddMediaPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;