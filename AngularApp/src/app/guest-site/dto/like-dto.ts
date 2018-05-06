export interface IPostLike{
    value: number,
    postId: number,
    commentId: number
}

export class PostLike implements IPostLike {
    value: number;
    postId: number;
    commentId: number;

    constructor(likeValue: number, postId: number, commentId: number){
        this.value = likeValue;
        this.postId = postId;
        this.commentId = commentId;
    }
}