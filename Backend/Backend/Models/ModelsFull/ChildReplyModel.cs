using Backend.Models.ModelsID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.ModelsFull
{
    public class ChildReplyModel : ReplyModel
    {
        public ParentReplyModel RootReply { get; set; }
        public UserModel ReplyTo { get; set; }

        public ChildReplyModel() { }

        public ChildReplyModel(uint iD, UserModel user, TopicModel topic,
            string content, DateTime createdAt, int rating, bool isDeleted,
            ParentReplyModel rootReply, UserModel replyTo)
        {
            ID = iD;
            User = user;
            Topic = topic;
            Content = content;
            CreatedAt = createdAt;
            Rating = rating;
            IsDeleted = isDeleted;
            RootReply = rootReply;
            ReplyTo = replyTo;
        }

        public ChildReplyModel(ChildReplyModelID childReply)
        {
            ID = childReply.ID;
            Content = childReply.Content;
            CreatedAt = childReply.CreatedAt;
            Rating = childReply.Rating;
            IsDeleted = childReply.IsDeleted;
        }


    }

   
}