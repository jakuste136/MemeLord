import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { RouterModule } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';
import { AuthGuardService } from './services/auth-guard.service';
import { LoginPageComponent } from './login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/material.module';
import { GuestSiteModule } from '../guest-site/guest-site.module';
import { RegisterPageComponent } from './register-page/register-page.component';
import { RegisterUserService } from './register-page/register-user.service';

@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    GuestSiteModule
  ],
  declarations: [NotFoundComponent, LoginPageComponent, RegisterPageComponent],
  exports: [
    RouterModule,
  ],
  providers: [
    AuthenticationService,
    AuthGuardService,
    RegisterUserService
  ]
})
export class CoreModule { }
