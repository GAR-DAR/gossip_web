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
import { AddChatComponent } from './navigation/chat/add-chat/add-chat.component';
import { AddChatUserComponent } from './navigation/chat/add-chat/add-chat-user/add-chat-user.component';

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
    AddChatComponent,
    AddChatUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
