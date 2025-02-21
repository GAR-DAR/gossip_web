import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-register-content-step2',
  standalone: false,
  
  templateUrl: './register-content-step2.component.html',
  styleUrl: './register-content-step2.component.scss'
})
export class RegisterContentStep2Component {
  @Output() nextPressedChange = new EventEmitter<boolean>();

  onNextPressed() {
    this.nextPressedChange.emit(false);
  }
}
