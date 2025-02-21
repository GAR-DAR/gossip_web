import { User } from "./user";

export interface ReplyModel {
    id: number;
    user: User;
    content: string;
    createdAt: Date;
    rating: number;
    isDeleted: boolean;
}