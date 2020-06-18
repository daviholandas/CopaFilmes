import { pegarResultado } from './../../store/competicao.actions';
import { Competicao } from './../../interfaces/competicao';
import { CompeticaoService } from './../../services/competicao.service';
import { Filme } from './../../interfaces/filme';
import { FilmeService } from './../../services/filme.service';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store'
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

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
    modalRef: BsModalRef
    mensagem: string
    @ViewChild('template', {static: true}) template: TemplateRef<any>;

    constructor(private filmeService: FilmeService, 
        private competicaoService: CompeticaoService,
        private router: Router,
        private store: Store<Competicao>,
        private modalService: BsModalService) { }

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
        if (this.filmesSelecionados.length > 8 )
        {
            this.openModal(this.template); 
            this.mensagem = "O numero maximo(8) de participantes já foi atigindo."
            this.filmesSelecionados.pop();
        }
        if (this.filmesSelecionados.length == 8 )
        {
            this.desativarBotaoGerar = false;
        }
        
    }

    gerarCompeticao(){
        this.competicaoService.criarCompeticao(this.filmesSelecionados)
            .subscribe(value =>{ 
                this.store.dispatch(pegarResultado(value));
                this.router.navigate(['resultado']);
            });
    }
    
    openModal(template: TemplateRef<any>){
        this.modalRef = this.modalService.show(template);
    }
    
}