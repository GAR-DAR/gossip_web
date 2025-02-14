import { InvokeFunctionExpr } from '@angular/compiler';
import { Component, Input } from '@angular/core';
import { Message } from '../../models/message';

@Component({
  selector: 'app-message',
  standalone: false,
  
  templateUrl: './message.component.html',
  styleUrl: './message.component.scss'
})
export class MessageComponent {
  @Input() message: Message = {
    text: 'ts pmo ♥ ts pmo ♥ ts pmo ♥ ts pmo ♥ ts pmo ♥ ts pmo ♥ ts pmo ♥ ts pmo ♥ ts pmo ♥ ',
    isIncoming: true,
    createdAt: new Date('2023-10-25T14:30:00')
  }
}
  