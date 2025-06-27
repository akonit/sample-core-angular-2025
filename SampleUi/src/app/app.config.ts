import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { AuthHttpInterceptor, authHttpInterceptorFn, provideAuth0 } from '@auth0/auth0-angular';

import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptors } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    { provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true },
    provideHttpClient(withInterceptors([authHttpInterceptorFn])),
    provideAuth0({
      domain: 'dev-4ukyzs2teelf2t62.us.auth0.com',
      clientId: 'O6KkxHDwR6GlG0IDerkR4NmxZUSlPIjd',
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: 'https://sampleProject/api',
      },
      httpInterceptor: {
        allowedList: [
          {
            uri: 'https://localhost:6457/*',
          },
        ],
      },
    }),
  ],
};
