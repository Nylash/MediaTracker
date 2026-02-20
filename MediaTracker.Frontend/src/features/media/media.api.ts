import type { Media } from "./media.types"

const BASE_URL = "https://localhost:7162/api";

export async function getMedia(): Promise<Media[]> {
  const response = await fetch(`${BASE_URL}/media`);

  if (!response.ok) {
    throw new Error("Erreur API");
  }

  return response.json();
}

export async function createMedia(title: string, category: string): Promise<Media> {
  const response = await fetch(`${BASE_URL}/media`, {
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