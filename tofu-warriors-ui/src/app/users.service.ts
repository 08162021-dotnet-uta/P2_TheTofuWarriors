import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  private apiUrl = 'https://localhost:44350';

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/User/userlist`);
  }

}
