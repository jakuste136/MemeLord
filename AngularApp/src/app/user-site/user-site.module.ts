import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserSiteRoutingModule } from './user-site-routing.module';
import { UserSiteComponent } from './user-site.component';
import { UserNavbarComponent } from './user-navbar/user-navbar.component';
import { MaterialModule } from '../shared/material.module';
import { PostsListComponent } from '../guest-site/posts-list/posts-list.component';
import { GuestSiteModule } from '../guest-site/guest-site.module';
import { UserProfileSiteComponent } from './user-profile-site/user-profile-site.component';
import { UserDetailsComponent } from './user-profile-site/user-details/user-details.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserDetailsService } from './user-profile-site/user-details/user-details.service';
import { JwtInterceptor } from '../core/services/jwt.inerceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    UserSiteRoutingModule,
    MaterialModule,
    GuestSiteModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    UserSiteComponent, 
    UserNavbarComponent, 
    UserProfileSiteComponent, 
    UserDetailsComponent],
  providers: [
    UserDetailsService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
  ]
})
export class UserSiteModule { }
