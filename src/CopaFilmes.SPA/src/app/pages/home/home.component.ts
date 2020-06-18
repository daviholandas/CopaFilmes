import { pegarResultado } from './../../store/competicao.actions';
import { Competicao } from './../../interfaces/competicao';
import { CompeticaoService } from './../../services/competicao.service';
import { Filme } from './../../interfaces/filme';
import { FilmeService } from './../../services/filme.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';

@Component({
    selector: 'app-home',
    templateUrl: 'home.component.html',
    styleUrls: ['home.component.css']
})

export class HomeComponent implements OnInit {
    filmes: Array<Filme> = [];
    filmesSelecionados: Array<Filme> = [];
    desativarSelecao = false;
    desativarBotaoGerar = true;
    selecionado: boolean;

    constructor(private filmeService: FilmeService, 
        private competicaoService: CompeticaoService,
        private router: Router,
        private store: Store<Competicao>) { }

    ngOnInit() {
        this.filmeService.getFilmes()
        .subscribe(values => this.filmes = values);
    }

    selecionarFilme(filme: Filme, index){
        if (!this.filmesSelecionados.includes(filme))
        {
            this.filmesSelecionados.push(filme);
        }else {
            this.filmesSelecionados.splice(index, 1);
        }
        if (this.filmesSelecionados.length >= 8 )
        {
            this.desativarBotaoGerar = false;
        }


        console.log(this.filmesSelecionados)
    }

    gerarCompeticao(){
        this.competicaoService.criarCompeticao(this.filmesSelecionados)
            .subscribe(value =>{ 
                this.store.dispatch(pegarResultado(value));
                this.router.navigate(['resultado']);
            });
    }
}