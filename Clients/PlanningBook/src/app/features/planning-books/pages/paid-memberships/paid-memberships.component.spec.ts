import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaidMembershipsComponent } from './paid-memberships.component';

describe('PaidMembershipsComponent', () => {
  let component: PaidMembershipsComponent;
  let fixture: ComponentFixture<PaidMembershipsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PaidMembershipsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaidMembershipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
