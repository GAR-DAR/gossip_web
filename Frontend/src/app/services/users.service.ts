import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModelId } from '../shared/models/idModels/topicModelId/userModelId';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  getUsersByIds(ids: number[]) : Observable<UserModelId[]> {
    return this.http.post<UserModelId[]>(`https://localhost:7062/Users/getusers`, ids);
  }
}
