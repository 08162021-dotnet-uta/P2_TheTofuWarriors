import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { shareReplay } from 'rxjs/operators';
import { User } from './user';
import { Following } from './Following';
import { Recipe } from './recipe';

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
//get all users
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

  getUserById(userId: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/User/${userId}`);
  }
  //follow a user 

  followUser(followerId:number, influencerId:number ):Observable<Following>{
    const url = `${this.apiUrl}/Following/follow`;
    let addFollowing = {
      followerId: followerId,
      influencerId: influencerId,

    }

  return this.http.post<Following>(url,addFollowing,this.httpOptions);
    
  }

  //remove following relationship 
  unfollowerUser(fId:number):Observable<Following>{
    const url = `${this.apiUrl}/Following/unfollow`;
    let deleteFollowing={
      followingId:fId
    }
    return this.http.delete<Following>(url,{
      headers:new HttpHeaders({
        "Content-Type":'application/json'
      }),
         body:deleteFollowing
    },
 
    );
   
  }

  //get following info of a user 

  getFollowingUserId(userId: number): Observable<Following[]> {
    return this.http.get<Following[]>(`${this.apiUrl}/Following/${userId}`);
  }
  //get user recipe by userId
  getRecipeUserId(userId: number): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${this.apiUrl}/User/${userId}/recipes`);
  }
}
