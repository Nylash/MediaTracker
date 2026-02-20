import { useEffect, useState } from "react";
import { getMedia, createMedia } from "./api";
import type { Media } from "./api";

function App() {
  const [media, setMedia] = useState<Media[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [title, setTitle] = useState("");
  const [category, setCategory] = useState(0);

  useEffect(() => {
    const fetchMedia = async () => {
      try {
        const data = await getMedia();
        setMedia(data);
      } catch {
        setError("Impossible de récupérer les médias");
      }
    };

    fetchMedia();
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      await createMedia(title, category);
      const updatedMedia = await getMedia();
      setMedia(updatedMedia);
      setTitle("");
    } catch (err) {
      setError("Erreur lors de la création");
    }
  };

  return (
    <div>
      <h1>MediaTracker</h1>

      {error && <p style={{ color: "red" }}>{error}</p>}

      <form onSubmit={handleSubmit}>
        <div>
          <input
            type="text"
            placeholder="Titre"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
        </div>

        <div>
          <input
            type="number"
            placeholder="Catégorie"
            value={category}
            onChange={(e) => setCategory(Number(e.target.value))}
          />
        </div>

        <button type="submit">Ajouter</button>
      </form>
      
      <ul>
        {media.map(m => (
          <li key={m.id}>
            {m.title} (catégorie: {m.category})
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;