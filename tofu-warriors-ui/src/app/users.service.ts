import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { shareReplay } from 'rxjs/operators';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  private currentUser: User | null = null;
  private apiUrl = environment.tofuWarriorsApiUrl;
  httpOptions={
    headers: new HttpHeaders({
      "Content-Type":'application/json'
    })
  };

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/User/userlist`);
  }

  //sign up , get user by userName & passord
  newUser(user:User):Observable<User>{
   
    const url = `${this.apiUrl}/User/register`;
    return this.http.post<User>(url,user,this.httpOptions);
  }

  //log in.
  logIn(userName:string, pw:string ):Observable<User>{
    const url = `${this.apiUrl}/User/login`;
    let user = {
      userName: userName,
      password: pw,

    }
    // use shareReplay operator to let multiple subscribers access same data
    // will avoid multiple http requests when subscribed to multiple times
    // To make another http request, logIn() function must be called again
    let result = this.http.post<User>(url,user,this.httpOptions).pipe(shareReplay())
    result.subscribe(data => this.currentUser = data);
    return result;
  }

  getCurrentUser(): User | null {
    return this.currentUser;
  }
}
