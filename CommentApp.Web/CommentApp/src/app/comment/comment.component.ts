import { Component, OnInit } from '@angular/core';
import { JwtService } from '../auth/jwt.service';
import { DataService } from '../service/data.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  public commentDetails:any[]=[];
  public pathURL='comment/';
  public newComment:any={};
  
  constructor(private service:DataService,private jwtService:JwtService) { }

  ngOnInit(): void {
    this.service.getRequest(this.pathURL).subscribe(response=>{
         this.commentDetails=response;
    });
  }
  onClickFilterCommentsByUser(){
     const userId =this.jwtService.getUserId('token');
     this.service.getRequestById(this.pathURL,userId).subscribe(reponse=>{
       this.commentDetails=reponse;
     });
  }

  onClickSubmit(){
    this.newComment.userId=this.jwtService.getUserId('token');
    this.service.createRequest(this.pathURL,this.newComment).subscribe(()=>{
     this.newComment.commentDescription=null;
     this.ngOnInit();
    });
  }
}
