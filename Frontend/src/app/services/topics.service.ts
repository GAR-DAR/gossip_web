import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Topic } from '../shared/models/topic';
import { TopicModelId } from '../shared/models/idModels/topicModelId/topicModelId';

@Injectable({
  providedIn: 'root'
})
export class TopicsService {
  private url = 'https://localhost:7062/Topics/home?page=1&amount=5';

  constructor(private http: HttpClient) { }

  getTopics() : Observable<TopicModelId[]> {
    return this.http.get<TopicModelId[]>(this.url);
  }
}
