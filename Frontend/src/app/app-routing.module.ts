import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './navigation/home/home.component';
import { AddTopicComponent } from './navigation/add-topic/add-topic.component';
import { ProfileEditComponent } from './navigation/profile-edit/profile-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'topics/create', component: AddTopicComponent},
  { path: 'user/edit', component: ProfileEditComponent}
];
