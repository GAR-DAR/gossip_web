import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthDialogComponent } from '../../auth/auth-dialog/auth-dialog/auth-dialog.component';

@Component({
  selector: 'app-topbar-unauth',
  standalone: false,
  templateUrl: './topbar-unauth.component.html',
  styleUrl: './topbar-unauth.component.scss'
})
export class TopbarUnauthComponent {
  constructor(private dialog: MatDialog) {}

  openLoginModal() {
    this.dialog.open(AuthDialogComponent, {
      width: '370px',
      height: '540px',
      disableClose: false
    });
  }
}
