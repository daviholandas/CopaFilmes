import { Observable } from 'rxjs';
import { Competicao } from './../../interfaces/competicao';
import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';

@Component({
    selector: 'app-resultado',
    templateUrl: 'resultado.component.html'
})

export class ResultadoComponent implements OnInit {
    resultadoCompeticao$: Observable<Competicao>;

    constructor(private store: Store<{resultado}>) {
        this.resultadoCompeticao$ = this.store.pipe(select('resultado'));
     }

    ngOnInit() {
    }
}