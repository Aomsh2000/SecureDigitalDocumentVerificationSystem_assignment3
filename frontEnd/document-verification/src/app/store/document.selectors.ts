// src/app/store/selectors/document.selectors.ts
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DocumentState } from './document.reducer';

export const selectDocumentState = createFeatureSelector<DocumentState>('document');

export const selectDocuments = createSelector(
  selectDocumentState,
  (state: DocumentState) => state.documents
);

export const selectLoading = createSelector(
  selectDocumentState,
  (state: DocumentState) => state.loading
);

export const selectError = createSelector(
  selectDocumentState,
  (state: DocumentState) => state.error
);
