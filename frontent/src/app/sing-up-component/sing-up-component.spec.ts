import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingUpComponent } from './sing-up-component';

describe('SingUpComponent', () => {
  let component: SingUpComponent;
  let fixture: ComponentFixture<SingUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingUpComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SingUpComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
