export class UpdatePostRequest{
    postId: number;
    rating: number;

    constructor(postId: number, rating: number){
        this.postId = postId;
        this.rating = rating;
    }
}