import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GuestSiteComponent } from './guest-site.component';
import { PostsListComponent } from './posts-list/posts-list.component';
import { TopComponent } from './top/top.component';
import { RandomComponent } from './random/random.component';

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
        path: 'top',
        component: TopComponent
      },
      {
        path: 'random',
        component: RandomComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GuestSiteRoutingModule { }
