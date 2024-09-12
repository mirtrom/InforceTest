import { ReactionType } from "../reaction-type.model";

export interface ReactionInput {
  pictureId: string;
  reactionType: ReactionType;
  userEmail: string;
}
