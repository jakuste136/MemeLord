import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../shared/material.module';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, RoutingComponents } from './app-routing.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { GuestNavbarComponent } from './guest-site/guest-navbar/guest-navbar.component';
import { PostComponent } from './guest-site/post/post.component';
import { GuestSiteComponent } from './guest-site/guest-site.component';
import { GuestSiteService } from './guest-site/guest-site.service';
import { RegisterUserService } from './register-page/register-user.service';



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
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [GuestSiteService, RegisterUserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
