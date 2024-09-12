import { Picture } from "./picture.model";
import { User } from "./user.model";

export interface Album {
  id: string;
  name: string;
  description: string;
  createdAt: Date;
  pictures: Picture[] | null;
  userId: string;
  userEmail: string;
}
