import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatComponent } from './navigation/chat/chat.component';
import { ChatElementComponent } from './navigation/chat/chat-element/chat-element.component';
import { ChatsListComponent } from './navigation/chat/chats-list/chats-list.component';
import { OpenedChatComponent } from './navigation/chat/opened-chat/opened-chat.component';
import { ChatTopbarComponent } from './navigation/chat/opened-chat/chat-topbar/chat-topbar.component';
import { InputComponent } from './navigation/chat/opened-chat/input/input.component';
import { MessagesFieldComponent } from './navigation/chat/opened-chat/messages-field/messages-field.component';
import { MessageComponent } from './shared/components/message/message.component';
import { AuthContentComponent } from './auth/auth-content/auth-content/auth-content.component';
import { AuthDialogComponent } from './auth/auth-dialog/auth-dialog/auth-dialog.component';
import { RegisterContentStep1Component } from './auth/register-content-step1/register-content-step1/register-content-step1.component';
import { RegisterContentStep2Component } from './auth/register-content-step2/register-content-step2/register-content-step2.component';
import { AddChatComponent } from './navigation/chat/add-chat/add-chat.component';
import { AddChatUserComponent } from './navigation/chat/add-chat/add-chat-user/add-chat-user.component';
import { AddTopicComponent } from './navigation/add-topic/add-topic.component';
import { TopbarAuthComponent } from './core/topbar-auth/topbar-auth.component'; 
import { TopbarUnauthComponent } from './core/topbar-unauth/topbar-unauth.component'; 
import { TopbarSearchComponent } from './core/topbar-search/topbar-search.component';
import { TopbarComponent } from './core/topbar/topbar.component';
import { SidebarComponent } from './core/sidebar/sidebar.component';
import { TopicComponent } from './shared/components/topic/topic.component';
import { HomeComponent } from './navigation/home/home.component';
import { provideHttpClient } from '@angular/common/http';
import { TestComponent } from './test/test.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button'; 

@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,
    ChatElementComponent,
    ChatsListComponent,
    OpenedChatComponent,
    ChatTopbarComponent,
    InputComponent,
    MessagesFieldComponent,
    MessageComponent,
    AuthContentComponent,
    AuthDialogComponent,
    RegisterContentStep1Component,
    RegisterContentStep2Component,
    AddChatComponent,
    AddChatUserComponent,
    AddTopicComponent,
    TopbarAuthComponent,
    TopbarUnauthComponent,
    TopbarSearchComponent,
    TopbarComponent,
    SidebarComponent,
    TopicComponent,
    HomeComponent,
    TestComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [ provideHttpClient() ],
  bootstrap: [AppComponent]
})
export class AppModule { }
