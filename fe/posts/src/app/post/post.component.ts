import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Post } from '../post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  @Input() post!: Post;
  @Output() deletedPost = new EventEmitter<Post>();
  constructor() { }

  ngOnInit(): void {
  }

  deletePost(post: Post){
    this.deletedPost.emit(post);
  }
}
