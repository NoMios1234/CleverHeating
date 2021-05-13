import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowOfficeComponent } from './show-office.component';

describe('ShowOfficeComponent', () => {
  let component: ShowOfficeComponent;
  let fixture: ComponentFixture<ShowOfficeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowOfficeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowOfficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
