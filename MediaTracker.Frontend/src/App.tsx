import { useEffect, useState } from "react";

interface Media {
  id: string;
  title: string;
  category: number;
}

function App() {
  const [media, setMedia] = useState<Media[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchMedia = async () => {
      try {
        const response = await fetch("https://localhost:7162/api/media");

        if (!response.ok) {
          throw new Error("Erreur API");
        }

        const data: Media[] = await response.json();
        setMedia(data);
      } catch (err) {
        setError("Impossible de récupérer les médias");
      }
    };

    fetchMedia();
  }, []);

  return (
    <div>
      <h1>MediaTracker</h1>

      {error && <p style={{ color: "red" }}>{error}</p>}

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