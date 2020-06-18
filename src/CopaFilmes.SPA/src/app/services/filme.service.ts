import { environment } from './../../environments/environment';
import { Filme } from './../interfaces/filme';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  constructor(private http: HttpClient) { }

  getFilmes(): Observable<Array<Filme>>{
    return this.http.get<Array<Filme>>(`${environment.baseUrl}filmes`);
  }
}

