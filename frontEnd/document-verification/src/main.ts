import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from './environments/environment';

// Import the reducer and effects
import { documentReducer } from './app/store/document.reducer';
import { DocumentEffects } from './app/store/document.effects';

// Now, configure everything properly
bootstrapApplication(AppComponent, {
  providers: [
    // Use `provideStore` to register the store
    provideStore({ document: documentReducer }),

    // Use `provideEffects` to register the effects
    provideEffects([DocumentEffects]),

    // Add StoreDevtoolsModule explicitly without `ModuleWithProviders`
    {
      provide: StoreDevtoolsModule,
      useFactory: () => StoreDevtoolsModule.instrument({
        maxAge: 25,
        logOnly: environment.production,  // Only log in production
      }),
    },
  ],
}).catch((err) => console.error(err));
