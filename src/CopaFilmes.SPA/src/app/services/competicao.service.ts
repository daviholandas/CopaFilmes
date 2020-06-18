import { Competicao } from './../interfaces/competicao';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { Filme } from './../interfaces/filme';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class CompeticaoService{
    constructor(private http: HttpClient){}

    criarCompeticao(filmes: Array<Filme>): Observable<Competicao>{
        return this.http.post<Competicao>(`${environment.baseUrl}competicao`, filmes);
    }
}
