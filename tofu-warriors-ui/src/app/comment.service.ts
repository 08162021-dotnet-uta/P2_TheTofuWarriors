import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from '../environments/environment';
import { Comment } from './comment';
import { RecipeService } from './recipe.service';
import { Observable, of } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(
    private http: HttpClient,
  ) { }

  apiUrl: string = environment.tofuWarriorsApiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": 'application/json'
    })
  };

  getCommentsBy(recipeId: number): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.apiUrl}/Recipe/${recipeId}/comment`);

  }
  newComment(comment: Comment): Observable<Comment> {
    const url = `${this.apiUrl}/Recipe/comment`;
    return this.http.post<Comment>(url, comment, this.httpOptions)


  }
}
