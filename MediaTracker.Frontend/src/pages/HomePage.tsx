import { useEffect, useState } from "react";
import { getMedia } from "../api";
import type { Media } from "../api";
import { Link } from "react-router-dom";

export default function HomePage() {
  const [media, setMedia] = useState<Media[]>([]);

  useEffect(() => {
    getMedia().then(setMedia);
  }, []);

  return (
    <div>
      <h1>Mes Médias</h1>

      <Link to="/add">Ajouter un média</Link>

      <ul>
        {media.map((m) => (
          <li key={m.id}>
            {m.title} ({m.category})
          </li>
        ))}
      </ul>
    </div>
  );
}