export type MediaStatus =
  | "Planned"
  | "InProgress"
  | "Completed"
  | "Abandoned";

export type Media = {
  id: string;
  title: string;
  category: string;
};

export type MediaEntry = {
  id: string;
  userId: string;
  mediaId: string;
  status: MediaStatus;
};