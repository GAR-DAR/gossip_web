import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-auth-dialog',
  standalone: false,
  
  templateUrl: './auth-dialog.component.html',
  styleUrl: './auth-dialog.component.scss'
})
export class AuthDialogComponent {
  @Input() login: string = '';
  @Input() password: string = '';
  constructor(private http: HttpClient, 
    private cookieService: CookieService,
    private dialogRef: MatDialogRef<AuthDialogComponent>
    ) {}

  onSubmit(): void {
    const choice = this.login.includes('@') ? 'email' : 'username';

    this.http.post<{ token: string }>(`https://localhost:7062/User/login/${choice}`, { login: this.login, password: this.password }).subscribe(
      res => {
        console.log(res);
        const token = res.token;
        this.cookieService.set('token', token);
        this.http.get(`https://localhost:7062/User/initToken?token=${token}`).subscribe(
          res => {
            console.log(res);
            localStorage.setItem('user', JSON.stringify(res));
          }
        );
      },
      err => {
        console.log(err);
      }
    );
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
