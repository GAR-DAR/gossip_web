import { ChildReply } from "./childReply";
import { ReplyModel } from "./replyModel";

export interface ParentReply extends ReplyModel {
    replies: ChildReply[];
}