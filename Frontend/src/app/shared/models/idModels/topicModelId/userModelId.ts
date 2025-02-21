export interface UserModelId {
    id: number;
    email: string;
    username: string;
    password: string;
    status: string;
    fieldOfStudy: string;
    specialization: string;
    university: string;
    term: number;
    degree: string;
    role: string;
    createdAt: Date;
    isBanned: boolean;
    photo: string;
    chatsID: number[];
}