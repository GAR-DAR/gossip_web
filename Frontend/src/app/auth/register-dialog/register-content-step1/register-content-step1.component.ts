import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-content-step1',
  standalone: false,
  
  templateUrl: './register-content-step1.component.html',
  styleUrl: './register-content-step1.component.scss'
})

export class RegisterContentStep1Component {
  @Output() nextPressedChange = new EventEmitter<boolean>();
  @Input() username: string = '';
  @Input() email: string = '';
  @Input() password: string = '';
  @Input() confirmPassword: string = '';

  onNextPressed(form: NgForm) {
    if (this.password != this.confirmPassword) {
      throw new Error('Passwords do not match');
    }

    try {
      this.nextPressedChange.emit(true);
    }
    catch (error) {
      console.error(error);
    }
  }
}
