import { createReducer, on } from '@ngrx/store';
import { loadDocuments, loadDocumentsSuccess, loadDocumentsFailure } from './document.actions';
import { Document } from '../models/document.model';

// Define the initial state
export interface DocumentState {
  documents: Document[];
  loading: boolean;
  error: string | null;
}

export const initialState: DocumentState = {
  documents: [],
  loading: false,
  error: null,
};

export const documentReducer = createReducer(
  initialState,
  on(loadDocuments, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(loadDocumentsSuccess, (state, { documents }) => ({
    ...state,
    documents,
    loading: false,
  })),
  on(loadDocumentsFailure, (state, { error }) => ({
    ...state,
    error,
    loading: false,
  }))
);
