import { Album } from "./album.model";

export interface Picture {
  id: string;
  title: string;
  url: string;
  createdAt: Date;
  fileExtension: string;
  albumId: string;
  album: Album;
  userEmail: string;
  likes: number;
  dislikes: number;
}
