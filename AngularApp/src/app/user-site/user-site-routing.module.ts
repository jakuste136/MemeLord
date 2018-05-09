import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserSiteComponent } from './user-site.component';
import { PostsListComponent } from '../guest-site/posts-list/posts-list.component';
import { RandomPostComponent } from '../guest-site/random/random-post.component';
import { TopComponent } from '../guest-site/top/top.component';
import { UserProfileSiteComponent } from './user-profile-site/user-profile-site.component';
import { PostDetailsComponent } from '../guest-site/posts-list/post-details/post-details.component';

const routes: Routes = [
  {
    path:'',
    component: UserSiteComponent,
    children: [
      {
        path: '',
        component: PostsListComponent
      },
      {
        path: 'post/:id',
        component: PostDetailsComponent
      },
      {
        path: 'top',
        component: TopComponent
      },
      {
        path: 'random',
        component: RandomPostComponent
      },
      {
        path: 'profile',
        component: UserProfileSiteComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserSiteRoutingModule { }
