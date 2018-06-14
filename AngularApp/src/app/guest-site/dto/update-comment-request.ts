export interface IUpdateCommentRequest{
    commentId: number,
    rating: number
}

export class UpdateCommentRequest implements IUpdateCommentRequest{
    commentId: number;
    rating: number;

    constructor(commentId: number, rating: number){
        this.commentId = commentId;
        this.rating = rating;
    }
}