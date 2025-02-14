import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-chats-list',
  standalone: false,
  
  templateUrl: './chats-list.component.html',
  styleUrl: './chats-list.component.scss'
})
export class ChatsListComponent {
  @Input() chats: any[] = [1, 2, 3, 4,1 ,1,1,1,1,];
}
