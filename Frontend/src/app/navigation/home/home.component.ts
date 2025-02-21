import { Component, Input, OnInit } from '@angular/core';
import { Topic } from '../../shared/models/topic';
import { User } from '../../shared/models/user';
import { ParentReply } from '../../shared/models/parentReply';
import { TopicsService } from '../../services/topics.service';
import { TopicModelId } from '../../shared/models/idModels/topicModelId/topicModelId';
import { UsersService } from '../../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{

  @Input() topics: Topic[] = [];

  
  constructor(private topicsService: TopicsService, 
    private usersService: UsersService,
    private router: Router) {}

    ngOnInit(): void {
      this.topicsService.getTopics().subscribe(topics => {
        this.usersService.getUsersByIds(topics.map(topic => topic.authorID)).subscribe(users => {
          topics.forEach(element => {
            this.topics.push({
              id: element.id,
              author: users.find(user => user.id === element.authorID) as User,
              title: element.title,
              content: element.content,
              createdAt: element.createdAt,
              rating: element.rating,
              tags: element.tags,
              replies: [],
              repliesCount: element.repliesCount,
              isDeleted: element.isDeleted
            });
          });
        });
      });
    }

    navigateToCreateTopic() : void {
      this.router.navigate(['/topics/create']);
    } 
}
