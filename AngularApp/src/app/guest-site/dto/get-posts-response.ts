import { IPostDto } from "./post-dto";

export interface IGetPostsResponse {
    lastId: number;
    postsList: Array<IPostDto>;
}