import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthDialogComponent } from '../../auth/auth-dialog/auth-dialog/auth-dialog.component';
import { RegisterContentStep1Component } from '../../auth/register-dialog/register-content-step1/register-content-step1.component';
import { RegisterDialogComponent } from '../../auth/register-dialog/register-dialog.component';

@Component({
  selector: 'app-topbar-unauth',
  standalone: false,
  templateUrl: './topbar-unauth.component.html',
  styleUrl: './topbar-unauth.component.scss'
})
export class TopbarUnauthComponent {
  constructor(private dialog: MatDialog) {}

  openSignupModal() {
    this.dialog.open(RegisterDialogComponent, {
      disableClose: false,
      panelClass: 'custom-dialog-container'
    }
    );
  }

  openLoginModal() {
    this.dialog.open(AuthDialogComponent, {
      disableClose: false,
      panelClass: 'custom-dialog-container'
    }
    );
  }
}
