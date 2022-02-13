import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtService } from 'src/app/auth/jwt.service';
import { DataService } from 'src/app/service/data.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public loginForm:FormGroup;
  public displayError:boolean=false;

  constructor(private service:DataService,private jwtService:JwtService,private router:Router) { }

  ngOnInit(): void {
    this.loginForm= new FormGroup(
      {
        emailId: new FormControl('',[Validators.required,Validators.email]),
        password: new FormControl('',[Validators.required]),
        secretCode: new FormControl('',[Validators.required])
      }
    );
  }

  onClickSignUp(value:any)
  {
    this.displayError=false;
    let pathUrl="useraccount/createaccount";
    this.service.createRequest(pathUrl,value).subscribe((response:any)=>{
      if(response?.token){
       this.jwtService.setToken('token',response.token);
       this.router.navigateByUrl('/comment');
      }
      else{
       this.displayError=true;
      }
      });
  }


}
