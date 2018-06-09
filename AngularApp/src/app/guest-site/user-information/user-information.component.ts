import { Component, OnInit, Input } from '@angular/core';
import { UserInformationService } from './user-information.service';
import { IAuthorUserDto, AuthorUserDto } from '../../core/register-page/dto/author-user-dto';

@Component({
  selector: 'app-user-information',
  templateUrl: './user-information.component.html',
  styleUrls: ['./user-information.component.scss']
})
export class UserInformationComponent implements OnInit {

  @Input() authorName: string;
  userInfo: AuthorUserDto = new AuthorUserDto();

  constructor(private _userInformationService: UserInformationService) {   
    this.userInfo.dateOfBirth = new Date(1996, 5, 31);
      this.userInfo.userName = "BestUsernameEver";
      this.userInfo.description = "I'm super cool guy. Never look back at explosions that I have just caused. Like to drink a lot and smoke weed every day. My biggest dream is that someday the whole world will be in peace.";

   }

  ngOnInit() {
    this._userInformationService.getUserInfo(this.authorName).subscribe(data => {
      //this.userInfo = data;
    });
    
  }

}
