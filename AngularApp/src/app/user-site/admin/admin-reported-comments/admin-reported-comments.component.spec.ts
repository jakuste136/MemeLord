import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminReportedCommentsComponent } from './admin-reported-comments.component';

describe('AdminReportedCommentsComponent', () => {
  let component: AdminReportedCommentsComponent;
  let fixture: ComponentFixture<AdminReportedCommentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminReportedCommentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminReportedCommentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
