import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../core/services/authentication.service';

@Component({
  selector: 'app-user-navbar',
  templateUrl: './user-navbar.component.html',
  styleUrls: ['./user-navbar.component.scss']
})
export class UserNavbarComponent implements OnInit {

  constructor(
    private _authenticationService: AuthenticationService,

  ) { }

  ngOnInit() {
  }

  logout(){
    this._authenticationService.logout();
  }
}
