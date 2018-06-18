import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserSiteRoutingModule } from './user-site-routing.module';
import { UserSiteComponent } from './user-site.component';
import { UserNavbarComponent } from './user-navbar/user-navbar.component';
import { MaterialModule } from '../shared/material.module';
import { PostsListComponent } from '../guest-site/posts-list/posts-list.component';
import { GuestSiteModule } from '../guest-site/guest-site.module';
import { UserProfileSiteComponent } from './user-profile-site/user-profile-site.component';
import { UserDetailsComponent } from './user-profile-site/user-details/user-details.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserDetailsService } from './user-profile-site/user-details/user-details.service';
import { JwtInterceptor } from '../core/services/jwt.inerceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';
import { AdminReportsComponent } from './admin/admin-reports/admin-reports.component';
import { UserReportService } from './report/report.service';
import { ReportComponent } from './report/report.component';
import { AdminReportedPostsComponent } from './admin/admin-reported-posts/admin-reported-posts.component';
import { AdminReportedCommentsComponent } from './admin/admin-reported-comments/admin-reported-comments.component';
import { AdminReportingService } from './admin/admin-reporting.service';

@NgModule({
  imports: [
    CommonModule,
    UserSiteRoutingModule,
    MaterialModule,
    GuestSiteModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    UserSiteComponent, 
    UserNavbarComponent, 
    UserProfileSiteComponent, 
    UserDetailsComponent,
    AdminComponent,
    AdminReportsComponent,
    ReportComponent,
    AdminReportedPostsComponent,
    AdminReportedCommentsComponent
  ],
  providers: [
    UserDetailsService,
    UserReportService,
    AdminReportingService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
  ]
})
export class UserSiteModule { }
