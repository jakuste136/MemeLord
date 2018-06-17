import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GuestSiteComponent } from './guest-site.component';
import { PostsListComponent } from './posts-list/posts-list.component';
import { TopComponent } from './top/top.component';
import { RandomPostComponent } from './random/random-post.component';
import { PostDetailsComponent } from './posts-list/post-details/post-details.component';
import { AuthorUserProfileComponent } from './author-user-profile/author-user-profile.component';
import { ReportComponent } from './report/report.component';

const routes: Routes = [
  {
    path: '',
    component: GuestSiteComponent,
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
        path: 'author/:authorName',
        component: AuthorUserProfileComponent
      },
      {
        path: 'report',
        component: ReportComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GuestSiteRoutingModule { }
