import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserSiteComponent } from './user-site.component';
import { PostsListComponent } from '../guest-site/posts-list/posts-list.component';
import { RandomPostComponent } from '../guest-site/random/random-post.component';
import { TopComponent } from '../guest-site/top/top.component';

const routes: Routes = [
  {
    path:'',
    component: UserSiteComponent,
    children: [
      {
        path: '',
        redirectTo: 'posts'
      },
      {
        path: 'posts',
        component: PostsListComponent
      },
      {
        path: 'top',
        component: TopComponent
      },
      {
        path: 'random',
        component: RandomPostComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserSiteRoutingModule { }
