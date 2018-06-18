import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminReportedPostsComponent } from './admin-reported-posts.component';

describe('AdminReportedPostsComponent', () => {
  let component: AdminReportedPostsComponent;
  let fixture: ComponentFixture<AdminReportedPostsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminReportedPostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminReportedPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
