import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { AuthGuardService } from './services/auth-guard.service';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'guest',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: 'register',
    component: RegisterPageComponent
  },
  {
    path: 'admin',
    canActivate: [AuthGuardService],
    loadChildren: '../admin/admin.module#AdminModule'
  },
  {
    path: 'guest',
    loadChildren: '../guest-site/guest-site.module#GuestSiteModule'
  },
  {
    path: 'user',
    canActivate: [AuthGuardService],
    loadChildren: '../user-site/user-site.module#UserSiteModule'
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
