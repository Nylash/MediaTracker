import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import type { Media, MediaEntry, MediaStatus } from "../media.types";
import { getMediaById, getMediaEntryByMediaId, createMediaEntry, updateMediaEntry, getEntryDeletionInfo, deleteMediaEntry } from "../media.api";
import { CURRENT_USER_ID } from "../../../app/constants";

export default function MediaDetailsPage() {
  const { mediaId } = useParams<{ mediaId: string }>();

  const [media, setMedia] = useState<Media | null>(null);
  const [entry, setEntry] = useState<MediaEntry | null>(null);
  const [status, setStatus] = useState<MediaStatus>("Planned");
  const [loading, setLoading] = useState(true);

  useEffect(() => {

    async function load() {
      if (!mediaId) return;

      try {
        const mediaData = await getMediaById(mediaId);
        setMedia(mediaData);

        const entryData = await getMediaEntryByMediaId(mediaId, CURRENT_USER_ID);
        setEntry(entryData); // peut être null et c’est ok
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    }

    load();
  }, [mediaId]);

  useEffect(() => {
    if (entry) {
      setStatus(entry.status);
    } else {
      setStatus("Planned");
    }
  }, [entry]);

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    if (!mediaId) return;

    const id = mediaId;

    if (entry) {
      const updated = await updateMediaEntry(entry.id, status);
      setEntry(updated);
    } else {
      const created = await createMediaEntry(CURRENT_USER_ID, id, status);
      setEntry(created);
    }
  }

  async function handleDelete() {
    if (!entry) return;

    const info = await getEntryDeletionInfo(entry.id);

    if (info.customLists > 0) {
      const confirmed = window.confirm(
        `Ce média est présent dans ${info.customLists} de vos listes personnalisées. Êtes-vous sûr ?`
      );

      if (!confirmed) return;
    }

    await deleteMediaEntry(entry.id);
    setEntry(null);
  }

  if (loading) return <p>Loading...</p>;
  if (!media) return <p>Media not found</p>;

  return (
    <div>
      <h1>{media.title}</h1>

      <form onSubmit={handleSubmit}>
        <select
          value={status}
          onChange={(e) => setStatus(e.target.value as MediaStatus)}
        >
          <option value="Planned">Planned</option>
          <option value="InProgress">In Progress</option>
          <option value="Completed">Completed</option>
          <option value="Abandoned">Abandoned</option>
        </select>

        <button type="submit">
          {entry ? "Mettre à jour" : "Ajouter à la liste"}
        </button>
            <div>
              {entry && (
                <button onClick={handleDelete}>
                  Supprimer
                </button>
              )}
          </div>
      </form>
    </div>
  );
}