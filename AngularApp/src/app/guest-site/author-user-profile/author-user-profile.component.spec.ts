import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorUserProfileComponent } from './author-user-profile.component';

describe('AuthorUserProfileComponent', () => {
  let component: AuthorUserProfileComponent;
  let fixture: ComponentFixture<AuthorUserProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthorUserProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthorUserProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
