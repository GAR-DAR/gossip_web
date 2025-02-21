export interface TopicModelId {
    id: number;
    authorID: number;
    title: string;
    content: string;
    createdAt: Date;
    rating: number;
    tags: string[];
    replies: number[];
    repliesCount: number;
    isDeleted: boolean;
}