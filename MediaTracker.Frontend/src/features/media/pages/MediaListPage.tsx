import { useEffect, useState } from "react";
import { getMedia } from "../media.api";
import type { Media } from "../media.types";
import { Link } from "react-router-dom";
import Card from "../../../components/ui/Card";

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
          <Card key={m.id}>
            {m.title} ({m.category})
          </Card>
        ))}
      </ul>
    </div>
  );
}