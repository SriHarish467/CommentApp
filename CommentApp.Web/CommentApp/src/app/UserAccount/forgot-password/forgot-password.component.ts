import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/service/data.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  public loginForm:FormGroup;
  public displayError:boolean=false;
  public showPassword:boolean=false;
  public userPassword:string;
  
  constructor(private service:DataService,private router:Router) { }

  ngOnInit(): void {
    this.loginForm= new FormGroup(
      {
        emailId: new FormControl('',[Validators.required,Validators.email]),
        secretCode: new FormControl('',[Validators.required])
      }
    );
  }
  onClickSignIn(value:any)
  {
    this.displayError=false;
    this.showPassword=false;
    let pathUrl="useraccount/forgotpassword";
    this.service.createRequest(pathUrl,value).subscribe((result:any)=>{
        this.showPassword=true;
        this.userPassword=result.password;
    },(error:HttpErrorResponse)=>{
      if(error.status == 401)
      {
         this.displayError=true;
      }
    });
  }

  onClickRedirectSignIn(){
    this.router.navigateByUrl('/login');
  }
}
