export interface IAuthorUserDto {
    userName: string;
    email: string;
    sex: string;
    dateOfBirth: Date;
    description: string;
    avatar: string;
}

export class AuthorUserDto implements IAuthorUserDto {
    userName: string;
    email: string;
    sex: string;
    dateOfBirth: Date;
    description: string;
    avatar: string;
}