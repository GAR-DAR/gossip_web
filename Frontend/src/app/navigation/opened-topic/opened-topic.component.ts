import { Component } from '@angular/core';

@Component({
  selector: 'app-opened-topic',
  standalone: false,
  
  templateUrl: './opened-topic.component.html',
  styleUrl: './opened-topic.component.scss'
})
export class OpenedTopicComponent {
  replies: any[] = [1, 2, 3, 4, 5];
  repliesToReplies: any[] = [1, 2];
}
