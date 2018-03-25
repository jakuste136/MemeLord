import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../shared/material.module';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, RoutingComponents } from './app-routing.module'

import { AppComponent } from './app.component';
import { GuestNavbarComponent } from './guest-navbar/guest-navbar.component';
import { PostComponent } from './guest-site/post/post.component';
import { GuestSiteComponent } from './guest-site/guest-site.component';
import { GuestSiteService } from './guest-site/guest-site.service';



@NgModule({
  declarations: [
    AppComponent,
    GuestNavbarComponent,
    PostComponent,
    GuestSiteComponent,
    RoutingComponents
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    InfiniteScrollModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [GuestSiteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
