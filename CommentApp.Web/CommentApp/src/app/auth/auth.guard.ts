import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtService } from './jwt.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router:Router,private jwtService:JwtService){}
  canActivate(): boolean {

      if(this.jwtService.getToken('token') ==null || this.jwtService.isTokenExpired('token'))
      {
        this.router.navigate(['/login']);
        return false;
      }
      else
      {
        return true;
      } 
  }
  
}
