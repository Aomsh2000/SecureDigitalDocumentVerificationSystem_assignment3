import { createAction, props } from '@ngrx/store';
import { Document } from '../models/document.model';

// Define actions for loading, success, and error states
export const loadDocuments = createAction('[Document] Load Documents');
export const loadDocumentsSuccess = createAction(
  '[Document] Load Documents Success',
  props<{ documents: Document[] }>()
);
export const loadDocumentsFailure = createAction(
  '[Document] Load Documents Failure',
  props<{ error: string }>()
);
