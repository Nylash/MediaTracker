import type { Media, MediaEntry, MediaStatus } from "./media.types";

const API_BASE = "https://localhost:7162/api";

export async function getMedia(): Promise<Media[]> {
  const response = await fetch(`${API_BASE}/media`);

  if (!response.ok) {
    throw new Error("Erreur API");
  }

  return response.json();
}

export async function createMedia(title: string, category: string): Promise<Media> {
  const response = await fetch(`${API_BASE}/media`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ title, category }),
  });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "Erreur lors de la création");
  }

  return response.json();
}


export async function getMediaById(id: string): Promise<Media> {
  const res = await fetch(`${API_BASE}/media/${id}`);
  return res.json();
}

export async function getMediaEntryByMediaId(
  mediaId: string,
  userId: string
): Promise<MediaEntry | null> {
  const res = await fetch(
    `${API_BASE}/mediaentry/by-media/${mediaId}?userId=${userId}`
  );

  if (!res.ok) {
    throw new Error("Failed to fetch media entry");
  }

  const text = await res.text();

  if (!text) {
    return null;
  }

  return JSON.parse(text);
}

export async function createMediaEntry(
  userId: string,
  mediaId: string,
  status: MediaStatus
): Promise<MediaEntry> {
  const res = await fetch(`${API_BASE}/mediaentry`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userId, mediaId, status }),
  });

  return res.json();
}

export async function updateMediaEntry(
  id: string,
  status: MediaStatus
): Promise<MediaEntry> {
  const res = await fetch(`${API_BASE}/mediaentry/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ status }),
  });

  return res.json();
}