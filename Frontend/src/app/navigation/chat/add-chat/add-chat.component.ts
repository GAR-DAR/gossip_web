import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-add-chat',
  standalone: false,
  
  templateUrl: './add-chat.component.html',
  styleUrl: './add-chat.component.scss'
})
export class AddChatComponent {
  @Input() users: any[] = [1, 1, 1, 1, 1, 1, 1, 1];
}
