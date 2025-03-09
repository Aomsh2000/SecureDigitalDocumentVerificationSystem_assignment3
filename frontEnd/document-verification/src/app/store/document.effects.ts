import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects'; // Import createEffect here
import { EMPTY } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { DocumentService } from '../services/document.service';
import { loadDocuments, loadDocumentsSuccess, loadDocumentsFailure } from './document.actions';

@Injectable()
export class DocumentEffects {

  loadDocuments$ = createEffect(() => this.actions$.pipe(
    ofType(loadDocuments),
    mergeMap(() => this.documentService.getDocuments()
      .pipe(
        map((documents) => loadDocumentsSuccess({ documents })),
        catchError((error) => EMPTY.pipe(map(() => loadDocumentsFailure({ error: error.message })))),
      )
    )
  ));

  constructor(
    private actions$: Actions,
    private documentService: DocumentService
  ) {}
}
