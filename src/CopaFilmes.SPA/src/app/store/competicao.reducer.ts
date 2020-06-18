import { pegarResultado } from './competicao.actions';
import { Filme } from './../interfaces/filme';
import { Competicao } from './../interfaces/competicao';
import { createReducer, on } from '@ngrx/store';
import { Action } from 'rxjs/internal/scheduler/Action';

export const initialState: Competicao = { 
    campeao: {id: '', titulo: '', ano: 0, nota: 0},
    viceCampeao: {id: '', titulo: '', ano: 0, nota: 0}
};

const _competicaoReduce = createReducer(initialState,
    on(pegarResultado, (state, props) => ({...props})));

export const competicaoReduce = (state: Competicao, action) => {
    return _competicaoReduce(state, action);
};
