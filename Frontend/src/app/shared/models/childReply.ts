import { ParentReply } from "./parentReply";
import { ReplyModel } from "./replyModel";
import { User } from "./user";

export interface ChildReply extends ReplyModel {
    rootReply: ParentReply;
    replyTo: User;
}

