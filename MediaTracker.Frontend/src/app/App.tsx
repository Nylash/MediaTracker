import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "../layout/Layout";
import MediaListPage from "../features/media/pages/MediaListPage";
import AddMediaPage from "../features/media/pages/AddMediaPage";
import MediaDetailsPage from "../features/media/pages/MediaDetailsPage.tsx";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<MediaListPage />} />
          <Route path="/add" element={<AddMediaPage />} />
          <Route path="/media/:mediaId" element={<MediaDetailsPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;