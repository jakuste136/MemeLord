import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserSiteRoutingModule } from './user-site-routing.module';
import { UserSiteComponent } from './user-site.component';
import { UserNavbarComponent } from './user-navbar/user-navbar.component';
import { MaterialModule } from '../shared/material.module';
import { PostsListComponent } from '../guest-site/posts-list/posts-list.component';
import { GuestSiteModule } from '../guest-site/guest-site.module';

@NgModule({
  imports: [
    CommonModule,
    UserSiteRoutingModule,
    MaterialModule,
    GuestSiteModule
  ],
  declarations: [UserSiteComponent, UserNavbarComponent]
})
export class UserSiteModule { }
