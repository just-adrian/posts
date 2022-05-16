import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Post } from '../post';
import { PostsService } from '../posts.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit, OnDestroy {

  posts: Post[] = [];
  subscriptions : Subscription[] = [];
  page: number = 1;

  constructor(private postService: PostsService) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(){
    let s = this.postService.getPosts(this.page).subscribe(x =>{
      this.posts = this.posts.concat(x);
      console.log(this.posts);
    });

    this.subscriptions.push(s);
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => {
      if(!x.closed) {
        x.unsubscribe();
      }
    });
  }

  onScroll() {
    this.page++;
    this.getPosts();
  }
}
