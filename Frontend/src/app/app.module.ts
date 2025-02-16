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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
