import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../shared/material.module';

import { AppComponent } from './app.component';
import { GuestNavbarComponent } from './guest-navbar/guest-navbar.component';
import { PostComponent } from './guest-site/post/post.component';
import { PostsListComponent } from './guest-site/posts-list/posts-list.component';
import { GuestSiteComponent } from './guest-site/guest-site.component';


@NgModule({
  declarations: [
    AppComponent,
    GuestNavbarComponent,
    PostComponent,
    PostsListComponent,
    GuestSiteComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
