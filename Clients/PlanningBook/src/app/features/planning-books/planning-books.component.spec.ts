import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanningBooksComponent } from './planning-books.component';

describe('PlanningBooksComponent', () => {
  let component: PlanningBooksComponent;
  let fixture: ComponentFixture<PlanningBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlanningBooksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlanningBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
