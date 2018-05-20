import { ICommentDto } from "./comment-dto";

export interface IMasterCommentDto{
    avatar: string,
    username: string,
    rating: number,
    answers: Array<ICommentDto>,
    creationDate: Date,
    text: string,
    id: number
}

export class MasterCommentDto implements IMasterCommentDto {
    avatar: string;
    username: string;
    rating: number;
    answers: Array<ICommentDto>;
    creationDate: Date;
    text: string;
    id: number;

    constructor(avatar: string, username: string, rating: number, answers: Array<ICommentDto>, creationDate: Date, text: string, id: number){
        this.avatar = avatar;
        this.username = username;
        this.rating = rating;
        this.answers = answers;
        this.creationDate = creationDate;
        this.text = text;
        this.id = id;
    }
}