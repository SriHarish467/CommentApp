import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private apiEndPoint= environment.apiEndPoint;

  constructor(private httpClient:HttpClient) { }

  //Get Method
  public getRequest(param:any):Observable<any>{
    return this.httpClient.get(this.apiEndPoint+param);
  }

  //Get By Id Method
  public getRequestById(param:string,id:any):Observable<any>{
    return this.httpClient.get(this.apiEndPoint+param+id);
  }

  //Post Create Method
  public createRequest(param:string,data:any):Observable<any>{
   return this.httpClient.post(this.apiEndPoint+param,data);
  }
}
