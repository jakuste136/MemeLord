import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GuestSiteRoutingModule } from './guest-site-routing.module';
import { GuestSiteComponent } from './guest-site.component';
import { GuestNavbarComponent } from './guest-navbar/guest-navbar.component';
import { MaterialModule } from '../shared/material.module';
import { PostComponent } from './post/post.component';
import { PostsListComponent } from './posts-list/posts-list.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { PostsListService } from './posts-list/posts-list.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginPageComponent } from '../core/login-page/login-page.component';
import { CoreModule } from '../core/core.module';
import { TopComponent } from './top/top.component';
import { RandomPostComponent } from './random/random-post.component';
import { AddPostModalComponent } from './posts-list/add-post-modal/add-post-modal.component';
import { AddPostService } from './posts-list/add-post-modal/add-post.service';


@NgModule({
  imports: [
    CommonModule,
    GuestSiteRoutingModule,
    MaterialModule,
    InfiniteScrollModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    GuestNavbarComponent
  ],
  declarations: [
    GuestSiteComponent,
    GuestNavbarComponent,
    PostComponent,
    PostsListComponent,
    TopComponent,
    RandomPostComponent,
    AddPostModalComponent],
  providers: [
    PostsListService,
    AddPostService
  ],
  entryComponents: [
    AddPostModalComponent
  ]
})
export class GuestSiteModule { }
