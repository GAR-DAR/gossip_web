import { Component, Input } from '@angular/core';
import { Topic } from '../../models/topic';

@Component({
  selector: 'app-topic',
  standalone: false,
  
  templateUrl: './topic.component.html',
  styleUrl: './topic.component.scss'
})
export class TopicComponent {
  @Input() topic!: Topic;
}
