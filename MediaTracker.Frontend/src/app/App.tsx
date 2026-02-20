import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "../layout/Layout";
import MediaListPage from "../features/media/pages/MediaListPage";
import AddMediaPage from "../features/media/pages/AddMediaPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<MediaListPage />} />
          <Route path="/add" element={<AddMediaPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;