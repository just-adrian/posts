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

  deletedPost: Post | null = null;

  constructor(private postService: PostsService) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(){
    let s = this.postService.getPosts(this.page).subscribe(x =>{
      this.posts = this.posts.concat(x);
    });

    this.subscriptions.push(s);
  }

  setDeletedPost(post: any){
    this.deletedPost = post;
  }

  onDeletePost(confirm: any){
    if (confirm && this.deletedPost) {
      let dp = this.postService.deletePost(this.deletedPost.id).subscribe(x =>
        {

          this.posts.forEach((value,index)=>{
            if(value.id==this.deletedPost!.id){
              this.posts.splice(index,1);
            }
          });
          this.deletedPost = null;
        });

      this.subscriptions.push(dp);
    }
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
