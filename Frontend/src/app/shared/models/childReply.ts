import { ParentReply } from "./parentReply";
import { User } from "./user";

export interface ChildReply {
    rootReply: ParentReply;
    replyTo: User;
}

