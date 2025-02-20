import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-auth-content',
  standalone: false,
  
  templateUrl: './auth-content.component.html',
  styleUrl: './auth-content.component.scss'
})
export class AuthContentComponent {
  @Input() login: string = '';
  @Input() password: string = '';

  constructor(private http: HttpClient) {}

  onSubmit() : void {
    if(this.login.includes('@'))
      this.http.post('https://localhost:7062/Users/login/email', {login: this.login, password: this.password }).subscribe();
  }
}
