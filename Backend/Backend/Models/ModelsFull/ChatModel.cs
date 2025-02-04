﻿using Backend.Models.ModelsID;
using System.Collections.ObjectModel;


namespace Backend.Models.ModelsFull
{
    [Serializable]
    public class ChatModel
    {
        public uint ID { get; set; }
        public List<UserModel> Users { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public List<MessageModel> Messages { get; set; } = [];

        public void AddMessage(MessageModel message)
        {
            Messages.Add(message);
        }

        public ChatModel(uint iD, List<UserModel> users, string name,
            DateTime createdAt, bool isDeleted, List<MessageModel> messages)
        {
            ID = iD;
            Users = users;
            Name = name;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
            Messages = messages;
        }

        public ChatModel() { }

        public ChatModel(ChatModelID chatModelID)
        {
            ID = chatModelID.ID;
            Users = null;
            Name = chatModelID.Name;
            CreatedAt = chatModelID.CreatedAt;
            IsDeleted = chatModelID.IsDeleted;
            Messages = null;
        }
    }

}