import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../shared/material.module';

import { AppComponent } from './app.component';
import { GuestNavbarComponent } from './guest-navbar/guest-navbar.component';


@NgModule({
  declarations: [
    AppComponent,
    GuestNavbarComponent
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
