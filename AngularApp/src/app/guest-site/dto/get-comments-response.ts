import { IMasterCommentDto} from './master-comment-dto'

export interface IGetCommentsResponse{
    lastId: number,
    commentsList: Array<IMasterCommentDto>
}

export class GetCommentsResponse implements IGetCommentsResponse {
    lastId: number;
    commentsList: Array<IMasterCommentDto>;

    constructor(lastId: number, commentsList: Array<IMasterCommentDto>){
        this.lastId = lastId;
        this.commentsList = commentsList;
    }
}