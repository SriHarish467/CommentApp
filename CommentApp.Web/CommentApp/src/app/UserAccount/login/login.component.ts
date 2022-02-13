import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtService } from 'src/app/auth/jwt.service';
import { DataService } from 'src/app/service/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm:FormGroup;
  public displayError:boolean=false;

  constructor(private service:DataService,private jwtService:JwtService,private router:Router) { }

  ngOnInit(): void {
    this.loginForm= new FormGroup(
      {
        emailId: new FormControl('',[Validators.required,Validators.email]),
        password: new FormControl('',[Validators.required])
      }
    );
  }
  onClickSignIn(value:any)
  {
    this.displayError=false;
    let pathUrl="useraccount/login";
    this.service.createRequest(pathUrl,value).subscribe((result:any)=>{
      this.jwtService.setToken('token',result.token);
      this.router.navigateByUrl('/comment');
      },(error:HttpErrorResponse)=>{
           if(error.status == 401)
           {
              this.displayError=true;
           }
      });
  }
}
