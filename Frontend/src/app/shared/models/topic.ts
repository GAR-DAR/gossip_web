import { ParentReply } from "./parentReply";
import { User } from "./user";

export interface Topic {
    id: number;
    author: User;
    title: string;
    content: string;
    createdAt: Date;
    rating: number;
    tags: string[];
    replies: ParentReply[];
    repliesCount: number;
    isDeleted: boolean;
}