import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  private apiUrl = 'https://localhost:44350';
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
  return this.http.post<User>(url,user,this.httpOptions);
}
}
