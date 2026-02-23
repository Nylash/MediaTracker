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
          <Link key={m.id} to={`/media/${m.id}`} style={{ textDecoration: "none" }}>
            <Card>
              {m.title} ({m.category})
            </Card>
          </Link>
        ))}
      </ul>
    </div>
  );
}