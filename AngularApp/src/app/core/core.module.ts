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
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './services/jwt.inerceptor';
import { AdminAuthGuardService } from './services/admin-auth-guard.service';

@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    GuestSiteModule,
    ToastrModule.forRoot({
      timeOut: 1500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    BrowserAnimationsModule
  ],
  declarations: [NotFoundComponent, LoginPageComponent, RegisterPageComponent],
  exports: [
    RouterModule,
  ],
  providers: [
    AuthenticationService,
    AuthGuardService,
    AdminAuthGuardService,
    RegisterUserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
  ]
})
export class CoreModule { }
