import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserSiteComponent } from './user-site.component';
import { PostsListComponent } from '../guest-site/posts-list/posts-list.component';

const routes: Routes = [
  {
    path:'',
    component: UserSiteComponent,
    children: [
      {
        path: '',
        component: PostsListComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserSiteRoutingModule { }
