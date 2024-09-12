import { Picture } from "./picture.model";
import { ReactionType } from "./reaction-type.model";
import { User } from "./user.model";

export interface Reaction {
  id: string;
  reactionType: ReactionType;
  user: User;
  createdAt: string;
  pictureId: string;
  picture: Picture;
}
