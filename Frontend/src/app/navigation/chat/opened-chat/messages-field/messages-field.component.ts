import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-messages-field',
  standalone: false,
  templateUrl: './messages-field.component.html',
  styleUrl: './messages-field.component.scss'
})
export class MessagesFieldComponent {
  @Input() messages: any[] = [1, 2, 3, 4, 1, 1,1,1,1,1,1,1, 1,1]
}
