import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthDialogComponent } from '../auth-dialog/auth-dialog/auth-dialog.component';

@Component({
  selector: 'app-register-dialog',
  standalone: false,
  
  templateUrl: './register-dialog.component.html',
  styleUrl: './register-dialog.component.scss'
})
export class RegisterDialogComponent {

  constructor(private dialogRef: MatDialogRef<AuthDialogComponent>) {}

  isNextPressed: boolean = false;

  onNextPressedChange(value: boolean) {
    this.isNextPressed = value;
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
