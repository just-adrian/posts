import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Post } from './post';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  constructor(private http: HttpClient) { }

  getPosts(page: number, filter: string){
    return this.http.get<Post[]>(`${environment.baseUrl}/api/post?number=${page}&filter=${filter}`);
  }

  deletePost(postId: number){
    return this.http.delete(`${environment.baseUrl}/api/post/${postId}`);
  }
}
