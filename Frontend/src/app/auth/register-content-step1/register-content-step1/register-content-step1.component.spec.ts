import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterContentStep1Component } from './register-content-step1.component';

describe('RegisterContentStep1Component', () => {
  let component: RegisterContentStep1Component;
  let fixture: ComponentFixture<RegisterContentStep1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegisterContentStep1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterContentStep1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
