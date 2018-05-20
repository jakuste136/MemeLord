export interface ILike{
    value: number,
    postId: number,
    commentId: number
}

export class Like implements ILike {
    value: number;
    postId: number;
    commentId: number;

    constructor(likeValue: number, postId: number, commentId: number){
        this.value = likeValue;
        this.postId = postId;
        this.commentId = commentId;
    }
}