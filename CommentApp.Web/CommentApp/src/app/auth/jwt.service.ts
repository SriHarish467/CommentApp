import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class JwtService {

  jwtToken: string;
  decodedToken: { [key: string]: string };
  constructor() { }

  setToken(key: string, value: string) {
    sessionStorage.setItem(key, value);
}

getToken(key: string) {
    this.jwtToken = sessionStorage.getItem(key);
    if(this.jwtToken == null)
    return null;
    else
    {
      return this.jwtToken;
    }
}

decodeToken(token:string) {
  this.jwtToken = sessionStorage.getItem(token);
  if(this.jwtToken){
    this.decodedToken = jwt_decode(this.jwtToken);
    return this.decodedToken;
  }
  else{
    return null;
  }
}

getUserId(token: string)
{
 this.decodeToken(token);
 return this.decodedToken['UserId']  ? this.decodedToken['UserId'] : null;
}

 getTokenExpirationDate(token: string) {
  const expiry:any = this.decodeToken(token);
 if(expiry)
 {
  return (Math.floor((new Date).getTime() / 1000)) >= expiry['exp'];
 }
 return false;
}

isTokenExpired(token: string): boolean {
  if (this.getTokenExpirationDate(token)) {
    return true;
  } else {
    return false;
  }
}

clearToken(key: string) {
    sessionStorage.removeItem(key);
}
}
