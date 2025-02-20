import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './navigation/home/home.component';
import { TestComponent } from './test/test.component';
import { AddTopicComponent } from './navigation/add-topic/add-topic.component';
import { OpenedTopicComponent } from './navigation/opened-topic/opened-topic.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'topics/create', component: AddTopicComponent },
  { path: 'topics/view', component: OpenedTopicComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
