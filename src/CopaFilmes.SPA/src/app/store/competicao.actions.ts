import { Competicao } from './../interfaces/competicao';
import { createAction, props } from '@ngrx/store'


export const pegarResultado = createAction('[Home Page] PegarResultado', props<Competicao>());
