import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { JwtService } from './jwt.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router:Router,private jwtService:JwtService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    
   if(this.jwtService.getToken('token') !==null && !this.jwtService.isTokenExpired('token'))
    {
      var token = this.jwtService.getToken('token');
      const req = request.clone({
        headers: request.headers.set(
          'Authorization',
          'Bearer ' + token
        )
      });

      return next.handle(req);
    }
    return next.handle(request);
  }
}
