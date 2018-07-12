export interface IAuthorUserDto {
    username: string;
    email: string;
    sex: string;
    dateOfBirth: Date;
    description: string;
    avatar: string;
}

export class AuthorUserDto implements IAuthorUserDto {
    username: string;
    email: string;
    sex: string;
    dateOfBirth: Date;
    description: string;
    avatar: string;
}