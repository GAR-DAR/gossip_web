import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterContentStep2Component } from './register-content-step2.component';

describe('RegisterContentStep2Component', () => {
  let component: RegisterContentStep2Component;
  let fixture: ComponentFixture<RegisterContentStep2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegisterContentStep2Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterContentStep2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
