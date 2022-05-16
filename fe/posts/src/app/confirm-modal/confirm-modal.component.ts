import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css']
})
export class ConfirmModalComponent implements OnInit {
  @Input() postId: number | null = null;

  @Output() delete = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  agree() {
    this.emitDeleteEvet(true);
  }

  disagree() {
    this.emitDeleteEvet(false);
  }

  emitDeleteEvet(agree: boolean){
    this.delete.emit(agree);
    this.postId = null;
  }
}
