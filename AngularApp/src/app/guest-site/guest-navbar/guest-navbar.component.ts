import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-guest-navbar',
  templateUrl: './guest-navbar.component.html',
  styleUrls: ['./guest-navbar.component.scss']
})
export class GuestNavbarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  routeToLogin(){
    this.router.navigate(['/login']);
  }

  routeToRegister(){
    this.router.navigate(['/register']);
  }
}
