import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { CommentComponent } from './comment/comment.component';
import { ForgotPasswordComponent } from './useraccount/forgot-password/forgot-password.component';
import { LoginComponent } from './useraccount/login/login.component';
import { SignUpComponent } from './useraccount/sign-up/sign-up.component';

const routes: Routes = [
  {
    path:'',
    component:SignUpComponent
  },
  {
    path:'signup',
    component:SignUpComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'forgotpassword',
    component:ForgotPasswordComponent
  },
  {
    path:'comment',
    component:CommentComponent,canActivate:[AuthGuard]
  },
  {
    path: '**',
    redirectTo:''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
