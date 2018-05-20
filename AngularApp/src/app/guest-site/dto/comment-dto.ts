export interface ICommentDto{
    avatar: string,
    username: string,
    rating: number,
    //masterCommentId: number,
    creationDate: Date,
    text: string,
    id: number
}

export class CommentDto implements ICommentDto {
    avatar: string;
    username: string;
    rating: number;
    //masterCommentId: number;
    creationDate: Date;
    text: string;
    id: number;

    constructor(avatar: string, username: string, rating: number, /*masterCommentId: number, */creationDate: Date, text: string, id: number){
        this.avatar = avatar;
        this.username = username;
        this.rating = rating;
        //this.masterCommentId = masterCommentId;
        this.creationDate = creationDate;
        this.text = text;
        this.id = id;
    }
}