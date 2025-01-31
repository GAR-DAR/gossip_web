import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopbarComponent } from './core/topbar/topbar.component';
import { TopbarUnauthComponent } from './core/topbar-unauth/topbar-unauth.component';
import { TopbarAuthComponent } from './core/topbar-auth/topbar-auth.component';
import { SidebarComponent } from './core/sidebar/sidebar.component';
import { HomeComponent } from './navigation/home/home.component';
import { ChatComponent } from './navigation/chat/chat.component';
import { AuthDialogComponent } from './auth/auth-dialog/auth-dialog.component';
import { AuthContentComponent } from './auth/auth-content/auth-content.component';
import { RegisterContentStep1Component } from './auth/register-content-step1/register-content-step1.component';
import { RegisterContentStep2Component } from './auth/register-content-step2/register-content-step2.component';
import { MessageComponent } from './shared/components/message/message.component';
import { TopicComponent } from './shared/components/topic/topic.component';
import { ChatsListComponent } from './navigation/chat/chats-list/chats-list.component';
import { ChatElementComponent } from './navigation/chat/chat-element/chat-element.component';
import { OpenedChatComponent } from './navigation/chat/opened-chat/opened-chat.component';
import { MessagesFieldComponent } from './navigation/chat/opened-chat/messages-field/messages-field.component';
import { InputComponent } from './navigation/chat/opened-chat/input/input.component';

@NgModule({
  declarations: [
    AppComponent,
    TopbarComponent,
    TopbarUnauthComponent,
    TopbarAuthComponent,
    SidebarComponent,
    HomeComponent,
    ChatComponent,
    AuthDialogComponent,
    AuthContentComponent,
    RegisterContentStep1Component,
    RegisterContentStep2Component,
    MessageComponent,
    TopicComponent,
    ChatsListComponent,
    ChatElementComponent,
    OpenedChatComponent,
    MessagesFieldComponent,
    InputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
